using System.Linq;
using BookStore.Models;
using BookStore.Models.PromoCodes.Items;

namespace BookStore.Services
{
    public static class CartService
    {
        //в своем решении я прибегнул к такому сценарию, если есть 2 скидки (по акции или по промокоду),
        //то будет выбираться наибольшая скидка, а не суммроваться (как в большинстве магазинов)
        public static double GetFinalPrice(Cart cart)
        {
            var totalSum = cart.Books.Select(i => i.Price).Sum();
            var stockSale = cart.Promo.GetSaleSum(cart.Books);
            var finalDeliverPrice = cart.Deliver?.GetDeliverPrice(cart.Books) ?? 0;
            var intermediatePrice = totalSum + finalDeliverPrice;
            var promoCodeItem = new PromoCodeItem(cart.Books, intermediatePrice, cart.Deliver.Value);
            var promoCodeSale = cart.PromoCode?.GetSaleSum(promoCodeItem) ?? 0;
            var resultSale = promoCodeSale > stockSale ? promoCodeSale : stockSale;

            return intermediatePrice - resultSale;
        }
    }
}