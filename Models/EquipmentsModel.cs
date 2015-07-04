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

        [Required]
        [Display(Name = "Quantity")]
        public string Quantity { get; set; }

        [Display(Name = "Remarks")]
        public string Remarks { get; set; }

        [Required]
        [Display(Name="Allow Claim ")]
        public bool ClaimType { get; set; }
    }
}