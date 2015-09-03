using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ChemisTrackCrud.Models
{
    public class AccountModel
    {
        [Key]
        public int userID { get; set; }

        [Required]
        [Display(Name = "User name")]
        [StringLength(150)]
        public string UserName { get; set; }

        [Required]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        [StringLength(200)]
        public string Password { get; set; }

        public string PasswordSalt { get; set; }

        //[Required]
        //[Display(Name = "Role")]
        //public string Role { get; set; }

    }
}