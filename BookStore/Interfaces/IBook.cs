using BookStore.Models;

namespace BookStore.Interfaces
{
    public interface IBook
    {
        public Author Author { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }
        public string EditorialOfficeName { get; set; }
        public double Price { get; set; }
    }
}