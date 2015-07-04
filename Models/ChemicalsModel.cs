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

        [Required]
        [Display(Name = "Chemical Name")]
        public string ChemicalName { get; set; }

        [Required]
        [Display(Name = "IUPAC Name")]
        public string ScientificName { get; set; }

        [Required]
        [Display(Name = "Nature")]
        public string Nature { get; set; }

        [Display(Name = "Color")]
        public string Color { get; set; }

        [Display(Name = "Odour")]
        public string Odour { get; set; }

        [Display(Name = "Melting Point")]
        public float MeltingPoint { get; set; }

        [Display(Name = "Boiling Point")]
        public float BoilingPoint { get; set; }

        [Display(Name = "Flammable Type")]
        public string Flammable { get; set; }

        [Display(Name = "Toxicity Type")]
        public string Toxicity { get; set; }

        [Display(Name="Hazardous Waste Type")]
        public string HazardousWaste { get; set; }
    }
}