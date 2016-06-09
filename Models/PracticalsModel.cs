using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ChemisTrackCrud.Models
{
    public class PracticalsModel
    {
        [Key]
        public int PracticalID { get; set; }

        public string PracticalNumber { get; set; }

        public string PracticalTitle { get; set; }

        public decimal StudentCount { get; set; }

        public ChemicalsModel chemicalmodel { get; set; }
        public int ChemicalID { get; set; }

        public decimal PerStudentUsage { get; set; }

        public decimal totalUsage {
            get { return StudentCount * PerStudentUsage; }
        }

        public string Indicators { get; set; }

        public EquipmentsModel Equipmentmodel { get; set; }
        public int EquipmentID { get; set; }

        public int PerStudentEquipment { get; set; }

        public decimal TotalEquipment { 
            get { return StudentCount * PerStudentEquipment; } 
        }

    }
}