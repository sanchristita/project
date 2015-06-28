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
        public string EquipmentName { get; set; }
        public string Quantity { get; set; }
        public string Price { get; set; }
        public string Type { get; set; }
    }
}