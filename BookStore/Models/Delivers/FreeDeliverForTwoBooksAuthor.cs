using System.Collections.Generic;
using System.Linq;
using BookStore.Interfaces;
using BookStore.Models.Books;

namespace BookStore.Models.Delivers
{
    public class FreeDeliverForTwoBooksAuthor: IDeliver
    {
        public double Value { get; set; }

        public double GetDeliverPrice(List<IBook> books)
        {
            var isFreeDeliver = books.Where(i => i is PaperBook)
                .Select(i => i.Price).Sum() >= 1000;

            return isFreeDeliver ? 0 : Value;
        }
    }
}