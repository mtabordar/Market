namespace MarketApi.Models
{
    using System;

    public class Product : BaseItem
    {
        public int QuantityInStock { get; set; }

        public decimal UnitPrice { get; set; }

        public bool IsBasic { get; set; }

        public int PeriodDuration { get; set; }

        public DateTime BuyDate { get; set; }
    }
}
