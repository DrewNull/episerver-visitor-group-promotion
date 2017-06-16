using System;
using System.Collections.Generic;
using System.Linq;
using EPiServer.Commerce.Marketing;
using EPiServer.Commerce.Order;
using EPiServer.Core;
using EPiServer.ServiceLocation;
using EPiServer.Web.Routing;
using Mediachase.Commerce;
using Mediachase.Commerce.Catalog;
using Mediachase.Commerce.Core;
using Mediachase.Commerce.Pricing;
using Website.Models.Variations;
using Website.ViewModels.Variations.MusicLesson;

namespace Website.Services
{
    public class MusicLessonVariationService
    {
        private static Injected<ICurrentMarket> _currentMarket;
        private static Injected<IPriceService> _priceService;
        private static Injected<IPromotionEngine> _promotionEngine;
        private static Injected<ReferenceConverter> _referenceConverter;
        private static Injected<ILineItemCalculator> _lineItemCalculator;
        private static Injected<UrlResolver> _urlResolver;

        public MusicLessonVariationViewModel GetViewModel(MusicLessonVariation currentContent)
        {
            var viewModel = new MusicLessonVariationViewModel();
            viewModel.Model = currentContent;

            // get list price
            var market = _currentMarket.Service.GetCurrentMarket();
            var listPrice = _priceService.Service
                .GetDefaultPrice(
                    market.MarketId,
                    DateTime.Now,
                    new CatalogKey(AppContext.Current.ApplicationId, currentContent.Code),
                    market.DefaultCurrency)
                .UnitPrice
                .Amount;
            viewModel.ListPrice = listPrice;

            // get discount price
            var discountEntries = _promotionEngine.Service
                .GetDiscountPrices(new List<ContentReference>
                {
                    currentContent.ContentLink
                },
                market,
                market.DefaultCurrency,
                _referenceConverter.Service,
                _lineItemCalculator.Service);
            decimal lowestDiscountedPrice =
                discountEntries.SelectMany(x => x.DiscountPrices).OrderBy(x => x.Price).FirstOrDefault()?.Price.Amount ??
                listPrice;
            viewModel.DiscountPrice = lowestDiscountedPrice;

            viewModel.Url = _urlResolver.Service.GetUrl(currentContent.ContentLink);

            return viewModel;
        }
    }
}