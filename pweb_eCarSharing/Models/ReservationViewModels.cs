using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace pweb_eCarSharing.Models
{
    public class NewReservationViewModel // modelo para informação de formulário
    {
        [Required]
        [Display(Name = "Desired Vehicle's ID number")]
        public int VehicleID { get; set; }
        
        [Required]
        [Display(Name = "Desired Vehicle's current station ID")]
        public int idStationIdstart { get; set; }
        
        [Required]
        [Display(Name = "Desired Vehicle's delivery station ID")]
        public int idStationIdEnd { get; set; }
        
        [Required]
        [Display(Name = "Total use time (in minutes)")]
        public int predictedUseTime { get; set; }
    }
}