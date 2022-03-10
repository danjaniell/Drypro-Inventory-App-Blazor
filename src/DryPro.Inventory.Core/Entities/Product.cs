using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DryPro.Inventory.Core.Entities
{
    public class Product : BaseTransactionModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [DisplayName("Type")]
        public ProductType Type { get; set; }
        [DisplayName("Color")]
        public ProductColor Color { get; set; }
        [DisplayName("Description")]
        [StringLength(255)]
        public string Description { get; set; }
        [DisplayName("Stock Items")]
        public int StockItems { get; set; }
    }

    public enum ProductType
    {
        [Display(Name = "Bath Towel")] BathTowel = 1,
        [Display(Name = "Hand Towel")] HandTowel
    }

    public enum ProductColor
    {
        Blue = 1,
        Yellow,
        Red,
        Gray,
        Pink,
        Purple,
    }
}