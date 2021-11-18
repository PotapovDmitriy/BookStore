using System.Collections.Generic;
using BookStore.Interfaces;

namespace BookStore.Models.PromoCodes
{
    public class FreeDeliverPromoCode : IPromoCode
    {
        public double GetSaleSum(IPromoCodeItem item)
            => item.DeliverPrice ?? 0;
    }
}