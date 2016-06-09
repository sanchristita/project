using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ChemisTrackCrud.Models
{
    public class WasteManagementModel
    {
        [Key]
        public int WasteManagementID { get; set; }

        //public ChemicalsModel ChemicalsModelObject { get; set; }
        public int ChemicalID { get; set; }

        public string ChemicalName { get; set; }

        public string HazardousWaste { get; set; }

        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        public int OrderNo { get; set; }

        public string SupplierName { get; set; }

        public decimal Quantity { get; set; }

        public string Unit { get; set; }

        public decimal UnitPrice { get; set; }

        public decimal Amount { get; set; }

        [DataType(DataType.Date)]
        public DateTime ExpiredDate { get; set; }

        public int GRN_No { get; set; }
    }
}