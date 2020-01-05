using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace pweb_eCarSharing.Models
{
    public class AddCarStationViewModel // modelo para informação de formulário
    {
        [Required]
        [StringLength(15, ErrorMessage = "Length must be between 3 and 15", MinimumLength = 3)]
        [Display(Name = "Car station location")]
        public string stationCity { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Length must be between 3 and 50", MinimumLength = 3)]
        [Display(Name = "Street Address")]
        public string stationAdress { get; set; }
    }

    public class RemCarStationViewModel
    { 
        [Required]
        [Display(Name = "Station id to remove")]
        public int stationID { get; set; }
    }
}