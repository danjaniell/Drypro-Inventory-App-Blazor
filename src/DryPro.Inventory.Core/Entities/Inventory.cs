using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DryPro.Inventory.Core.Entities
{
    public class Inventory : BaseTransactionModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [DisplayName("Name")]
        [StringLength(55)]
        public string Name { get; set; }
        [DisplayName("Description")]
        [StringLength(255)]
        public string Description { get; set; }
        [DisplayName("Stock Items")]
        public int StockItems { get; set; }
        [DisplayName("Cost")]
        public decimal Cost { get; set; }
    }
}