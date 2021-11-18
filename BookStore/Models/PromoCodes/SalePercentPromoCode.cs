using System.Collections.Generic;
using BookStore.Interfaces;

namespace BookStore.Models.PromoCodes
{
    public class SalePercentPromoCode : IPromoCode
    {
        public SalePercentPromoCode(double value)
        {
            Value = value;
        }

        public double Value { get; set; }

        public double GetSaleSum(IPromoCodeItem item)
            => Value * (item.TotalSum ?? 0) / 100;
    }
}