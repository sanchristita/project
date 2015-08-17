using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ChemisTrackCrud.Models
{
    public class PracticalModel
    {
        [Key]
        public int PracticalID { get; set; }

        public string PracticalName { get; set; }

        public int PracticalYear { get; set; }

        public ChemicalsModel Chemicals { get; set; }
        public List<ChemicalsModel> ChemicalID { get; set; }

        public EquipmentsModel Equipments { get; set; }
        public int EquipmentID { get; set; }

    }
}