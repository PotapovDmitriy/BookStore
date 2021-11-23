using System;
using BookStore.Interfaces;

namespace BookStore.Models.PromoCodes
{
    public class SalePercentPromoCode : IPromoCode
    {
        public SalePercentPromoCode(double value)
        {
            if (value > 100 || value < 0)
                throw new ArgumentOutOfRangeException(nameof(Value));

            Value = value;
        }

        public double Value { get; set; }

        public double GetSaleSum(IPromoCodeItem item)
            => Value * (item.TotalSum ?? 0) / 100;
    }
}