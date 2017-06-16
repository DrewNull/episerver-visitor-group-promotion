using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EPiServer.Commerce.Extensions;
using EPiServer.Commerce.Marketing;
using EPiServer.Framework.Localization;
using EPiServer.Personalization.VisitorGroups;
using EPiServer.ServiceLocation;
using Website.Models.Promotions.VisitorGroupDiscount;

namespace Website.PromotionProcessors.VisitorGroupDiscount
{
    public class VisitorGroupDiscountPromotionProcessor : EntryPromotionProcessorBase<VisitorGroupDiscountPromotion>
    {
        private readonly Injected<CollectionTargetEvaluator> _targetEvaluator;
        private readonly Injected<FulfillmentEvaluator> _fulfillmentEvaluator;
        private readonly Injected<LocalizationService> _localizationService;
        private readonly Injected<IVisitorGroupRepository> _visitorGroupRepository;
        private readonly Injected<IVisitorGroupRoleRepository> _visitorGroupRoleRepository;

        protected override PromotionItems GetPromotionItems(VisitorGroupDiscountPromotion promotionData)
        {
            var items = new CatalogItemSelection(
                promotionData.Entries,
                CatalogItemSelectionType.Specific,
                true);

            return new PromotionItems(promotionData, items, items);
        }

        protected override RewardDescription Evaluate(VisitorGroupDiscountPromotion promotionData, PromotionProcessorContext context)
        {
            // get all items from the cart
            var lineItems = this.GetLineItems(context.OrderForm).ToList();

            // get any codes that the promotion applies to (check visitor group to filter)
            Guid visitorGroupGuid;
            Guid.TryParse(promotionData.VisitorGroup, out visitorGroupGuid);
            var user = HttpContext.Current.User;
            var visitorGroupHelper = new VisitorGroupHelper(this._visitorGroupRoleRepository.Service);
            var visitorGroup = this._visitorGroupRepository.Service.Load(visitorGroupGuid);
            var isVisitorGroup = visitorGroupHelper.IsPrincipalInGroup(user, visitorGroup.Name);
            var applicableCodes = isVisitorGroup
                ? this._targetEvaluator.Service.GetApplicableCodes(lineItems, promotionData.Entries, true).ToList()
                : new List<string>();

            // check to see whether the promotion has been fulfilled
            var fulfillmentStatus = this._fulfillmentEvaluator.Service
                .GetStatusForBuyFromCategoryPromotion(applicableCodes, lineItems);

            // get redemption status
            var redemptions = new List<RedemptionDescription>();
            var affectedEntries = context.EntryPrices.ExtractEntries(applicableCodes, 1);
            if (affectedEntries != null)
                redemptions.Add(this.CreateRedemptionDescription(affectedEntries));

            return RewardDescription.CreatePercentageReward(
                fulfillmentStatus,
                redemptions,
                promotionData,
                promotionData.Percentage,
                fulfillmentStatus.GetRewardDescriptionText(this._localizationService.Service));
        }
    }
}