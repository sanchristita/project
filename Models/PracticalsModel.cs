using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ChemisTrackCrud.Models
{
    public class PracticalsModel
    {
        [Key]
        public int PracticalID { get; set; }

        public string PracticalName { get; set; }

        public int PracticalYear { get; set; }

        public ChemicalsModel AvailableChemicls { get; set; }
        public int ChemicalID { get; set; }

        public EquipmentsModel AvailableEquipments { get; set; }
        public int EquipmentID { get; set; }
    }
}