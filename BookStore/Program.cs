using System;
using System.Collections.Generic;
using BookStore.Enums;
using BookStore.Interfaces;
using BookStore.Models;
using BookStore.Models.Books;
using BookStore.Models.Delivers;
using BookStore.Models.PromoCodes;
using BookStore.Models.Stocks;
using BookStore.Services;

namespace BookStore
{
    class Program
    {
        private static IPromo _promo;
        private static IDeliver _deliver;
        private static Cart _cart1, _cart2;
        private static IPromoCode _freeBookPromo, _freeDeliverPromo, _percentPromo, _saleCurrencyPromo;
        private static Author _author1, _author2, _author3;
        private static IBook _eBook1, _eBook2, _eBook3, _paperBook1, _paperBook2, _paperBook3, _paperBook4, _paperBook5;

        static void Main(string[] args)
        {
            InitializeModels();
            InitializeCarts();
            var totalPrice1 = CartService.GetFinalPrice(_cart1);
            var totalPrice2 = CartService.GetFinalPrice(_cart2);
        }

        private static void InitializeCarts()
        {
            _cart1 = new Cart
            {
                Promo = _promo, PromoCode = _freeBookPromo,
                Books = new List<IBook> {_eBook1, _paperBook1, _paperBook2},
                Deliver = _deliver
            };

            _cart2 = new Cart
            {
                Promo = _promo, PromoCode = _freeDeliverPromo,
                Books = new List<IBook> {_eBook2, _paperBook3, _paperBook4},
                Deliver = _deliver
            };
        }

        private static void InitializeModels()
        {
            _author1 = new Author
            {
                Birthdate = DateTime.Now, Name = "Автор 1"
            };
            _author2 = new Author
            {
                Birthdate = DateTime.Now, Name = "Автор 2"
            };
            _author3 = new Author
            {
                Birthdate = DateTime.Now, Name = "Автор 3"
            };
            _eBook1 = new EBook
            {
                Author = _author1, Name = "Электронная книга 1", Price = 100, Year = 2019, EditorialOfficeName = "Name"
            };
            _eBook2 = new EBook
            {
                Author = _author2, Name = "Электронная книга 2", Price = 150, Year = 2019, EditorialOfficeName = "Name"
            };
            _eBook3 = new EBook
            {
                Author = _author3, Name = "Электронная книга 3", Price = 340, Year = 2019, EditorialOfficeName = "Name"
            };
            _paperBook1 = new PaperBook
            {
                Author = _author1, Name = "Бумажная книга 1", Price = 550, Year = 2019, EditorialOfficeName = "Name"
            };
            _paperBook2 = new PaperBook
            {
                Author = _author1, Name = "Бумажная книга 2", Price = 700, Year = 2019, EditorialOfficeName = "Name"
            };
            _paperBook3 = new PaperBook
            {
                Author = _author2, Name = "Бумажная книга 3", Price = 350, Year = 2019, EditorialOfficeName = "Name"
            };
            _paperBook4 = new PaperBook
            {
                Author = _author2, Name = "Бумажная книга 4", Price = 200, Year = 2019, EditorialOfficeName = "Name"
            };
            _paperBook5 = new PaperBook
            {
                Author = _author3, Name = "Бумажная книга 5", Price = 800, Year = 2019, EditorialOfficeName = "Name"
            };
            _promo = new FreeEBookPromo();
            _freeBookPromo = new FreeBookPromoCode(_paperBook3);
            _freeDeliverPromo = new FreeDeliverPromoCode();
            _percentPromo = new SalePercentPromoCode(30);
            _saleCurrencyPromo = new SaleCurrencyPromoCode(200);
            _deliver = new FreeDeliverForTwoBooksAuthor
            {
                Value = 200
            };
        }
    }
}