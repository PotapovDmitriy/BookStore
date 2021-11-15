﻿using System.Collections.Generic;
using BookStore.Interfaces;

namespace BookStore.Models.PromoCodes
{
    public class FreeBookPromoCode : IPromoCode
    {
        public IBook Book { get; }

        public FreeBookPromoCode(IBook book) { Book = book; }

        public double GetSaleSum(List<IBook> books, double totalSum, double deliverPrice) =>
            books.Contains(Book) ? Book.Price : 0;
    }
}