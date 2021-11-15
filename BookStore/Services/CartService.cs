using System.Collections.Generic;
using System.Linq;
using BookStore.Interfaces;
using BookStore.Models;
using BookStore.Models.Books;

namespace BookStore.Services
{
    public static class CartService
    {
        //в своем решении я прибегнул к такому сценарию, если есть 2 скидки (по акции или по промокоду),
        //то будет выбираться наибольшая скидка, а не суммроваться (как в большинстве магазинов)
        public static double GetFinalPrice(Cart cart, double deliverPrice = 200)
        {
            var totalSum = cart.Books.Select(i => i.Price).Sum();
            var stockSale = cart.Stock.GetSaleSum(cart.Books);
            var finalDeliverPrice = GetDeliverPrice(cart.Books, deliverPrice);
            var intermediatePrice = totalSum + finalDeliverPrice;
            var promoCodeSale = cart.PromoCode.GetSaleSum(cart.Books, intermediatePrice, deliverPrice);
            var resultSale = promoCodeSale > stockSale ? promoCodeSale : stockSale;
            
            return intermediatePrice - resultSale;
        }

        private static double GetDeliverPrice(List<IBook> books, double deliverPrice)
        {
            var isFreeDeliver = books.Where(i => i is PaperBook)
                .Select(i => i.Price).Sum() >= 1000;

            return isFreeDeliver ? 0 : deliverPrice;
        }
    }
}