using System.Collections.Generic;
using BookStore.Interfaces;

namespace BookStore.Models.PromoCodes
{
    public class FreeDeliverPromoCode : IPromoCode
    {
        public double GetSaleSum(List<IBook> books, double totalSum, double deliverPrice)
            => deliverPrice;
    }
}