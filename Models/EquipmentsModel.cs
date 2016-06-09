using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ChemisTrackCrud.Models
{
    public class EquipmentsModel
    {
        [Key]
        public int EquipmentID { get; set; }

        [Required]
        [Display(Name = "Equipment Name")]
        public string EquipmentName { get; set; }

        [Display(Name = "Model Type")]
        public string Model { get; set; }

        [Display(Name = "Remarks")]
        public string Remarks { get; set; }

        [Display(Name = "Allow Claim ")]
        public bool ClaimType { get; set; }

        public decimal EquipmentStockCount { get; set; }

        [Display(Name = "Standard Price for Claim")]
        public decimal claimStandardPrice { get; set; }
    }
}