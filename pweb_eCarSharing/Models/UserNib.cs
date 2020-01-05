using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace pweb_eCarSharing.Models
{
    public class UserNIB
    {
        [Key]
        public int userNIBID { get; set; }

        public string userIDstring { get; set; }
        
        [Required]
        [StringLength(21, ErrorMessage = "Length must be exactly 21 digits", MinimumLength = 21)]
        public string NIB { get; set; }
        
        [Required]
        [StringLength(7, ErrorMessage = "Length must be between 1 and 7", MinimumLength = 1)]
        public string Role { get; set; }

    }
}