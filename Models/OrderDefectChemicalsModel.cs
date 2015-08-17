using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ChemisTrackCrud.Models
{
    public class OrderDefectChemicalsModel
    {
        [Key]
        public int OrderDefectChemicalsID { get; set; }

        [Required]
        public string OrderNo { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Date of Order Returned")]
        public DateTime DefectDate { get; set; }

        public ChemicalsModel chemicals {get; set;}
        public int ChemicalID { get; set; }

        [Required]
        [Display(Name = "Quantity")]
        public decimal DefectQuantity { get; set; }

        [Required]
        [Display(Name = "Supplier Name")]
        public string DefectSupplierName { get; set; }

    }
}