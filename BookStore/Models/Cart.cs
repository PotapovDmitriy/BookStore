using System.Collections.Generic;
using BookStore.Interfaces;

namespace BookStore.Models
{
    public class Cart
    {
        public Stock Stock { get; set; }
        public PromoCode PromoCode { get; set; }
        public List<IBook> Books { get; set; }
    }
}