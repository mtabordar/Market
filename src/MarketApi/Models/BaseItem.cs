namespace MarketApi.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class BaseItem
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(254)]
        public string Name { get; set; }

        public DateTime UpdatedAt { get; set; }
    }
}
