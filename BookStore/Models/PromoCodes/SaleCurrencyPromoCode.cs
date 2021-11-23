using System;
using System.Collections.Generic;
using BookStore.Interfaces;

namespace BookStore.Models.PromoCodes
{
    public class SaleCurrencyPromoCode : IPromoCode
    {
        public SaleCurrencyPromoCode(double value) { Value = value; }

        public double Value { get; set; }

        public double GetSaleSum(IPromoCodeItem item)
            => item.TotalSum is null ? 0 : Math.Min((double)item.TotalSum, Value);
    }
}