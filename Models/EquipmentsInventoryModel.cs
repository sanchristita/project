using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ChemisTrackCrud.Models
{
    public class EquipmentsInventoryModel
    {
        [Key]
        public int EquipmentInventoryID { get; set; }

        // Create object for ChemicalsModel
        public EquipmentsModel Equipments { get; set; }
        public int EquipmentID { get; set; }

        //public virtual ICollection<EquipmentsModel> EquipmentsModelNames { get; set; } 

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Date of Order Received")]
        public DateTime EquipmentOrderDate { get; set; }

        [Required(ErrorMessage = "Order No must be an integer value.")]
        [Display(Name = "Order No")]
        public int EquipmentOrderNo { get; set; }

        [Required]
        [Display(Name = "Supplier Name")]
        public string EquipmentSupplierName { get; set; }

        [Required]
        [Display(Name = "Quantity")]
        public decimal EquipmentQuantity { get; set; }

        [Required]
        [Display(Name = "Unit Price")]
        public decimal EquipmentUnitPrice { get; set; }

        [Display(Name = "Amount")]
        public decimal EquipmentAmount { get { return EquipmentQuantity * EquipmentUnitPrice; } }

        [Display(Name = "GRN No/SRN No")]
        public int GRN_No { get; set; }
  
    }
}