using System.Collections.Generic;
using BookStore.Interfaces;

namespace BookStore.Models
{
    public class Cart
    {
        public IPromo Promo { get; set; }
        public IPromoCode PromoCode { get; set; }
        public List<IBook> Books { get; set; }
        public IDeliver Deliver { get; set; }
    }
}