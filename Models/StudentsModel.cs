using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ChemisTrackCrud.Models
{
    public class StudentsModel
    {
        [Key]
        public int StudentID { get; set; }
        public string StudentName { get; set; }
        public int Year { get; set; }
    }
}