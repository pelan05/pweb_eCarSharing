using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace pweb_eCarSharing.Models
{
    public class User
    {
        [Key]
        public int userID { get; set; }
        
        /*[ForeignKey("Reservation")]
        public List<int> reservationHistory { get; set; }
        public virtual Reservation Reservation { get; set; }*/

        [Required]
        public string name { get; set; }
        
        [Required]
        public bool isAdmin { get; set; } //true-gets admin privileges//false-gets normal user privileges

        public string address { get; set; }

        [DataType(DataType.Date)]
        public DateTime birthDate { get; set; }

        [Required]
        [EmailAddress]
        public string email { get; set; }

        [Required]//regex??????
        [StringLength(21, ErrorMessage = "Length must be exactly 21 digits", MinimumLength = 21)]
        public string NIB { get; set; }

    }
}