using System.Collections.Generic;

namespace BookStore.Interfaces
{
    public interface IPromo
    {
        double GetSaleSum(List<IBook> books);
    }
}