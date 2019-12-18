﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace pweb_eCarSharing.Models
{
    public class User
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int userID { get; set; }
        
        [ForeignKey("Reservation")]
        public List<int> reservationHistory { get; set; }

        [Required]
        public string name { get; set; }

        [StringLength(10, ErrorMessage = "Length must be between 3 and 10", MinimumLength = 3)]
        [Required]
        public string username { get; set; }//r->should these be here?
        [StringLength(10, ErrorMessage = "Length must be between 3 and 10", MinimumLength = 3)]
        [Required]
        public string password { get; set; }

        [Required]
        public bool isAdmin { get; set; } //true-gets admin privileges//false-gets normal user privileges

        public string adress { get; set; }

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