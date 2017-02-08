namespace MarketApi.ViewModels
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class ProductViewModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255, MinimumLength =5)]
        public string Name { get; set; }

        [Required]
        public int QuantityInStock { get; set; }

        [Required]
        public decimal UnitPrice { get; set; }

        [Required]
        public bool IsBasic { get; set; }

        [Required]
        public float PeriodDurationPerUnit { get; set; }

        public DateTime BuyDate { get; set; }
    }
}
