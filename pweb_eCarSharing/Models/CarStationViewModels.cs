using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace pweb_eCarSharing.Models
{
    public class AddCarStationViewModel // modelo para informação de formulário
    {
        [Key]
        [Required]
        [Display(Name = "CarStation's ID number")]
        public int CarStationID { get; set; }

        [Required]
        [StringLength(15, ErrorMessage = "Length must be between 3 and 15", MinimumLength = 3)]
        [Display(Name = "In what city is the station?")]
        public string stationCity { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Length must be between 3 and 50", MinimumLength = 3)]
        [Display(Name = "The Adress where it is at:")]
        public string stationAdress { get; set; }
    }
}