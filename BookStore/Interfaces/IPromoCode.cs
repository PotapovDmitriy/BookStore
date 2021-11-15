using System.Collections.Generic;

namespace BookStore.Interfaces
{
    public interface IPromoCode
    {
        double GetSaleSum(List<IBook> books, double totalSum, double deliverPrice);
    }
}