using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using EPiServer.Commerce;
using EPiServer.Commerce.Marketing;
using EPiServer.Commerce.Marketing.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAnnotations;
using EPiServer.Shell.ObjectEditing;
using Website.SelectionFactories.VisitorGroup;

namespace Website.Models.Promotions.VisitorGroupDiscount
{
    [ContentType(
        DisplayName = "Visitor Group Discount",
        Description = "If a user belongs to a vistor group, receive a discount",
        GUID = "7382F067-5157-4725-994F-61DCA301582D")]
    public class VisitorGroupDiscountPromotion : EntryPromotion
    {
        [PromotionRegion(PromotionRegionName.Condition)]
        [Display(
            Name = "Visitor Group",
            Order = 100)]
        [SelectOne(SelectionFactoryType = typeof(VisitorGroupSelectionFactory))]
        public virtual string VisitorGroup { get; set; }

        [PromotionRegion(PromotionRegionName.Discount)]
        [Display(
            Name = "Catalog Entries",
            Order = 200)]
        [UIHint(UIHint.CatalogContent)]
        public virtual IList<ContentReference> Entries { get; set; }

        [PromotionRegion(PromotionRegionName.Reward)]
        [Display(
            Name = "Percentage Off",
            Order = 300)]
        [UIHint(UIHint.DecimalEditor)]
        public virtual int Percentage { get; set; }
    }
}