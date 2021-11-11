using BookStore.Interfaces;

namespace BookStore.Models
{
    public class PaperBook : IBook
    {
        public Author Author { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }
        public string EditorialOfficeName { get; set; }
        public double Price { get; set; }
    }
}