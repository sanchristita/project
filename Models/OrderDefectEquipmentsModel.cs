using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ChemisTrackCrud.Models
{
    public class OrderDefectEquipmentsModel
    {
        [Key]
        public int OrderDefectEquipmentsID { get; set; }

        [Required]
        public EquipmentsInventoryModel equipmentsInventory { get; set; }
        public string OrderNo { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Date of Order Returned")]
        public DateTime EquipmenDefectDate { get; set; }

        public EquipmentsModel equipments { get; set; }
        public string EquipmentName { get; set; }

        [Required]
        [Display(Name = "Quantity")]
        public decimal DefectEquimentsQuantity { get; set; }

        [Required]
        [Display(Name = "Supplier Name")]
        public string DefectEquipmentSupplierName { get; set; }

    }
}