using System.Collections.Generic;
using BookStore.Interfaces;

namespace BookStore.Models.PromoCodes
{
    public class FreeBookPromoCode : IPromoCode
    {
        public IBook Book { get; }

        public FreeBookPromoCode(IBook book) { Book = book; }

        public double GetSaleSum(List<IBook> books, double? totalSum = null, double? deliverPrice = null) =>
            books.Contains(Book) ? Book.Price : 0;
    }
}