using System.Collections.Generic;

namespace BookStore.Interfaces
{
    public interface IPromoCode
    {
        double GetSaleSum(IPromoCodeItem item);
    }
}