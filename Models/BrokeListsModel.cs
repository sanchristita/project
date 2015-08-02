using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ChemisTrackCrud.Models
{
    public class BrokeListsModel
    {
        [Key]
        public int BrokeListsID { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Date")]
        public DateTime BrokeDate { get; set; }

        // Create object for ChemicalsModel 
        public EquipmentsModel Equipments { get; set; }
        public int EquipmentID { get; set; }

        [Required]
        [Display(Name = "Quantity")]
        public decimal UsedQuantity { get; set; }

        public decimal EquipmentStockCount { get; set; }

    }
}