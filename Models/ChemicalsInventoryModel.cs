using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ChemisTrackCrud.Models
{
    public class ChemicalsInventoryModel
    {
        [Key]
        public int ChemicalsInventoryID { get; set; }

        // Create object for ChemicalsModel 
        public ChemicalsModel Chemicals { get; set; }
        public int ChemicalID { get; set; }

        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [Required]
        [Display(Name = "Order No")]
        public int OrderNo { get; set; }

        [Required]
        [Display(Name = "Supplier Name")]
        public string SupplierName { get; set; }

        [Required]
        [Display(Name = "Quantity")]
        public decimal Quantity { get; set; }

        [Required]
        [Display(Name = "Unit Price")]
        [Range(1,100)]
        [DataType(DataType.Currency)]
        public decimal UnitPrice { get; set; }

        [Display(Name = "Amount")]
        public decimal Amount { get { return Quantity * UnitPrice; } }

        [Display(Name="GRN No/SRN No")]
        public int GRN_No { get; set; }

        [Display(Name = "Stock Balance")]
        public float StockBalance { get; set; }

    }
}