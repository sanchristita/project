using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ChemisTrackCrud.Models
{
    public class ChemicalsModel
    {
        [Key]
        public int ChemicalID { get; set; }
        public string ChemicalName { get; set; }
        public string ScientificName { get; set; }
        public string Nature { get; set; }
        public string Color { get; set; }
        public string Odour { get; set; }
        public float MeltingPoint { get; set; }
        public float BoilingPoint { get; set; }
        public string Flamable { get; set; }
        public string Toxicity { get; set; }
    }
}