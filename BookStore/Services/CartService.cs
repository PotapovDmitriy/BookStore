using System;
using System.Collections.Generic;
using System.Linq;
using BookStore.Enums;
using BookStore.Interfaces;
using BookStore.Models;

namespace BookStore.Services
{
    public static class CartService
    {
        public static double GetFinalPrice(Cart cart, double deliverPrice = 200)
        {
            var totalSum = cart.Books.Select(i => i.Price).Sum();
            var stockSale = GetStockSale(cart.Books, cart.Stock, cart.PromoCode);
            var finalDeliverPrice = GetDeliverPrice(cart.Books, deliverPrice);
            var intermediatePrice = totalSum + finalDeliverPrice - stockSale;
            var promoCodeSale = GetSaleByPromoCode(cart.Books, cart.PromoCode, intermediatePrice, deliverPrice); 
            
            return intermediatePrice - promoCodeSale;
        }

        private static double GetStockSale(List<IBook> books, Stock stock, PromoCode promoCode)
        {
            double result = 0;
            switch (stock.Type)
            {
                case StockType.FreeEBook:
                {
                    var freeEBook = CheckFreeEBook(books, promoCode);
                    result = freeEBook?.Price ?? 0;
                    break;
                }
                default:
                    throw new ArgumentOutOfRangeException();
            }

            return result;
        }

        private static IBook CheckFreeEBook(IReadOnlyCollection<IBook> books, PromoCode promoCode)
        {
            var paperBook = books.Where(i => i is PaperBook).ToList();
            var targetAuthorDict = paperBook.GroupBy(i => i.Author).Select(group => new
            {
                Author = group.Key,
                Count = group.Count()
            });

            var targetAuthor = targetAuthorDict.FirstOrDefault(i => i.Count > 1)?.Author;
            if (targetAuthor is null)
                return null;

            var resultBook = books
                .FirstOrDefault(i => i.Author == targetAuthor && i is EBook
                                                              && promoCode?.FreeBook?.Author != targetAuthor);

            return resultBook;
        }

        private static double GetDeliverPrice(List<IBook> books, double deliverPrice)
        {
            var isFreeDeliver = books.Where(i => i is PaperBook)
                .Select(i => i.Price).Sum() >= 1000;
            
            return isFreeDeliver ? 0 : deliverPrice;
        }

        private static double GetSaleByPromoCode(List<IBook> books, PromoCode promoCode, double totalSum, double deliverPrice)
        {
            return promoCode.Type switch
            {
                PromoCodeType.FreeBook => books.Contains(promoCode.FreeBook) ? promoCode.FreeBook.Price : 0,
                PromoCodeType.FreeDeliver => deliverPrice,
                PromoCodeType.SaleCurrency => promoCode.SaleCurrencyValue ?? 0,
                PromoCodeType.SalePercent => promoCode.SalePercentValue is null
                    ? 0
                    : (double) promoCode.SalePercentValue * totalSum / 100,
                _ => 0
            };
        }
    }
}