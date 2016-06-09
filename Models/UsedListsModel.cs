using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ChemisTrackCrud.Models
{
    public class UsedListsModel
    {
        [Key]
        public int UsedListsID { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Date")]
        public DateTime UsedDate { get; set; }

        [Required]
        [Display(Name = "PracticalNo")]
        public string PracticalNo { get; set; }

        [Display(Name = "Year")]
        public int YearOfCourse { get; set; }

        // Create object for ChemicalsModel 
        public ChemicalsModel Chemicals { get; set; }
        public int ChemicalID { get; set; }

        [Required]
        [Display(Name = "Quantity")]
        public decimal UsedQuantity { get; set; }

        public decimal ChemicalStockCount { get; set; }

    }
}