using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using WebGrease;

namespace ChemisTrackCrud.Models
{
    public class ChemicalsInventoryModel : IValidatableObject
    {
        [Key]
        public int ChemicalsInventoryID { get; set; }
        // Create object for ChemicalsModel 
        public ChemicalsModel Chemicals { get; set; }
        public int ChemicalID { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [Display(Name="Date of Order Received")]
        public DateTime Date { get; set; }
        [Required(ErrorMessage="Order No must be an integer value.")]
        [Display(Name = "Order No")]
        public int OrderNo { get; set; }
        [Required]
        [Display(Name = "Supplier Name")]
        public string SupplierName { get; set; }
        [Required]
        [Display(Name = "Quantity")]
        public decimal Quantity { get; set; }
        public string Unit { get; set; }
        [Required]
        [Display(Name = "Unit Price")]
        public decimal UnitPrice { get; set; }
        [Display(Name = "Amount")]
        public decimal Amount { get { return Quantity * UnitPrice; } }
        [Required]
        [DataType(DataType.Date)]
        [Display(Name="Date of Expired")]
        public DateTime ExpiredDate { get; set; }
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Date > ExpiredDate)
            {
                yield return new ValidationResult("ExpiredDate must be greater than Order ReceivedDate");
            }
        }
        [Display(Name="GRN No/SRN No")]
        public int GRN_No { get; set; }

        
    }
}