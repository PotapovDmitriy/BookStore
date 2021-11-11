using System;
using BookStore.Enums;
using BookStore.Interfaces;

namespace BookStore.Models
{
    public class PromoCode
    {
        public PromoCode(PromoCodeType type, IBook freeBook = null, double? salePercentValue = null,
            double? saleCurrencyValue = null)
        {
            Type = type;
            switch (type)
            {
                case PromoCodeType.FreeBook:
                    FreeBook = freeBook;
                    break;
                case PromoCodeType.FreeDeliver:
                    break;
                case PromoCodeType.SalePercent:
                    SalePercentValue = salePercentValue;
                    break;
                case PromoCodeType.SaleCurrency:
                    SaleCurrencyValue = saleCurrencyValue;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }
        }

        public double? SalePercentValue { get; }
        public double? SaleCurrencyValue { get; }
        public IBook FreeBook { get; }
        public PromoCodeType Type { get; }
    }
}