using System.Collections.Generic;
using BookStore.Interfaces;

namespace BookStore.Models.PromoCodes.Items
{
    /// <summary>
    /// Описывает входящие параметры
    /// </summary>
    public class PromoCodeItem : IPromoCodeItem
    {
        public PromoCodeItem(List<IBook> books, double? totalSum, double? deliverPrice)
        {
            Books = books;
            TotalSum = totalSum;
            DeliverPrice = deliverPrice;
        }

        public List<IBook> Books { get; set; }
        public double? TotalSum { get; set; }
        public double? DeliverPrice { get; set; }
    }
}