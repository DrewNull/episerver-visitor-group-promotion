# Promotions and Personalization Demo
## Episerver Chicago 2017 Summer Meetup
The purpose of this solution is to provide a quick demo of a custom promotion that uses a visitor group as a promo condition.

## Setup
Tweak the Web.Debug.config files in both the Website and Commerce projects to set the database (remove the transform lines). 

## Demo
For the interesting bits, see:
* [VisitorGroupDiscountPromotion.cs](https://github.com/DrewNull/promotions-and-personalization-demo/blob/master/Website/Models/Promotions/VisitorGroupDiscount/VisitorGroupDiscountPromotion.cs)
* [VisitorGroupDiscountPromotionProcessor.cs](https://github.com/DrewNull/promotions-and-personalization-demo/blob/master/Website/PromotionProcessors/VisitorGroupDiscount/VisitorGroupDiscountPromotionProcessor.cs)
