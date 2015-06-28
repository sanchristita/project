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
        public int StudentID { get; set; }
        public int EquipmentID { get; set; }
        public int Quantity { get; set; }
    }
}