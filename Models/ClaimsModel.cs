using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ChemisTrackCrud.Models
{
    public class ClaimsModel
    {
        [Key]
        public int ClaimID { get; set; }

        public StudentsModel Student { get; set; }
        public int StudentID { get; set; }
        public string RegistrationNumber { get; set; }

        public EquipmentsModel equipment{ get; set; }
        public int EquipmentID { get; set; }

        public int Quantity { get; set; }

        public decimal ClaimAmount {
            get {
                return Quantity * equipment.claimStandardPrice;
            }
        }

        public decimal TotalClaim { get; set; }
    }
}