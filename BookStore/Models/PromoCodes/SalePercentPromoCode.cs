﻿using System.Collections.Generic;
using BookStore.Interfaces;

namespace BookStore.Models.PromoCodes
{
    public class SalePercentPromoCode: IPromoCode
    {
        public SalePercentPromoCode(double value) { Value = value; }

        public double Value { get; set; }

        public double GetSaleSum(List<IBook> books, double totalSum, double deliverPrice)
            => Value * totalSum / 100;
    }
}