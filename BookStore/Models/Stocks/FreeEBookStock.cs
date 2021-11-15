using System.Collections.Generic;
using System.Linq;
using BookStore.Interfaces;
using BookStore.Models.Books;

namespace BookStore.Models.Stocks
{
    public class FreeEBookStock : IStock
    {
        public double GetSaleSum(List<IBook> books)
        {
            var paperBook = books.Where(i => i is PaperBook).ToList();
            var targetAuthorDict = paperBook.GroupBy(i => i.Author).Select(group => new
            {
                Author = group.Key,
                Count = group.Count()
            });

            var targetAuthor = targetAuthorDict.FirstOrDefault(i => i.Count > 1)?.Author;
            if (targetAuthor is null)
                return 0;

            var resultBook = books
                .FirstOrDefault(i => i.Author == targetAuthor && i is EBook);

            return resultBook?.Price ?? 0;
        }
    }
}