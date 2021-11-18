using System.Collections.Generic;

namespace BookStore.Interfaces
{
    public interface IDeliver
    {
        public double Value { get; set; }
        double GetDeliverPrice(List<IBook> books);
    }
}