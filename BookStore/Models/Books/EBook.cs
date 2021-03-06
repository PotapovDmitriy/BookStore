using BookStore.Interfaces;

namespace BookStore.Models.Books
{
    public class EBook : IBook
    {
        public Author Author { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }
        public string EditorialOfficeName { get; set; }
        public double Price { get; set; }
    }
}