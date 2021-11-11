using System;
using System.Collections.Generic;
using System.Linq;
using BookStore.Enums;
using BookStore.Interfaces;
using BookStore.Models;

namespace BookStore.Services
{
    public class CartService
    {
        //deliverPrice = 200

        public double GetFinalPrice(Cart cart, double deliverPrice = 200)
        {
            var totalSum = cart.Books.Select(i => i.Price).Sum();

            return 0;
        }

        private double GetStockSale(List<IBook> books, Stock stock)
        {
            double result = 0;
            switch (stock.Type)
            {
                case StockType.FreeEBook:
                {
                    var freeEBook = CheckFreeEBook(books);
                    result = freeEBook?.Price ?? 0;
                    break;
                }
                default:
                    throw new ArgumentOutOfRangeException();
            }

            return result;
        }

        private IBook CheckFreeEBook(List<IBook> books)
        {
            var paperBook = books.Where(i => i is PaperBook).ToList();
            var targetAuthor = paperBook.GroupBy(i => i.Author).Select(group => new
            {
                Author = group.Key,
                Count = group.Count()
            });
            

        }
    }
}