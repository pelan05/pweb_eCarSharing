using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace pweb_eCarSharing.Models
{
    public class CarStation
    {
        [Key]
        public int stationId { get; set; }

        [Required]
        [StringLength(15, ErrorMessage = "Length must be between 3 and 15", MinimumLength = 3)]
        public string stationCity { get; set; }//e.g. Porto

        [Required]
        [StringLength(50, ErrorMessage = "Length must be between 3 and 50", MinimumLength = 3)]
        public string stationAdress { get; set; }//e.g. Rua Voz dos ridículos, 123

    }
}