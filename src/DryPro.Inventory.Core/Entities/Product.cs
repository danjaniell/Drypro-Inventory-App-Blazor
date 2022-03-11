using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DryPro.Inventory.Core.Entities
{
    public class Product : BaseTransactionModel
    {
        private ProductType _type;
        private ProductColor _color;

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [DisplayName("Type")]
        public string Type
        {
            get { return _type == 0 ? string.Empty : _type.ToString(); }
            set
            {
                if (Enum.TryParse(value, out ProductType type)) { _type = type; }
                else { _type = 0; }
            }
        }
        [DisplayName("Color")]
        public string Color
        {
            get { return _color == 0 ? string.Empty : _color.ToString(); }
            set
            {
                if (Enum.TryParse(value, out ProductColor color)) { _color = color; }
                else { _color = 0; }
            }
        }
        [DisplayName("Description")]
        [StringLength(255)]
        public string Description { get; set; }
        [DisplayName("Stock Items")]
        public int StockItems { get; set; }
        [DisplayName("Cost")]
        public decimal Cost { get; set; }
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