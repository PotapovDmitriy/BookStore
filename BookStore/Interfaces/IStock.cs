using System.Collections.Generic;

namespace BookStore.Interfaces
{
    public interface IStock
    {
        double GetSaleSum(List<IBook> books);
    }
}