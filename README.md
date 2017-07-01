# Episerver Visitor Group Promotion Demo
The purpose of this solution is to provide a quick demo of a custom promotion type that uses a visitor group as a condition. It was put together for the Episerver Chicago 2017 Summer Meetup. Download the PowerPoint deck for the presentation [here](https://github.com/DrewNull/episerver-visitor-group-promotion/raw/master/Summer%202017%20Episerver%20Developer%20%26%20Editor%20Meetup.pptx)

## Setup
Tweak the Web.Debug.config files in both the Website and Commerce projects to set the database (remove the transform lines). 

## Demo
For the interesting bits, see:
* [VisitorGroupDiscountPromotion.cs](https://github.com/DrewNull/promotions-and-personalization-demo/blob/master/Website/Models/Promotions/VisitorGroupDiscount/VisitorGroupDiscountPromotion.cs)
* [VisitorGroupDiscountPromotionProcessor.cs](https://github.com/DrewNull/promotions-and-personalization-demo/blob/master/Website/PromotionProcessors/VisitorGroupDiscount/VisitorGroupDiscountPromotionProcessor.cs)
