using System.Collections.Generic;

namespace BookStore.Interfaces
{
    public interface IPromoCodeItem
    {
        public List<IBook> Books { get; set; }
        public double? TotalSum { get; set; }
        public double? DeliverPrice { get; set; }
    }
}