using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace pweb_eCarSharing.Models
{
    public class NewVehicleViewModel // modelo para informação de formulário
    {

        [Required]
        [Display(Name = "Vehicle's current station ID number")]
        public int? currentStationId { get; set; }

        [Required]
        [StringLength(11, ErrorMessage = "The field must equal one of the 4 options.", MinimumLength = 4)]
        [Display(Name = "Vehicle Type (SCOOTER/BIKE/MOTORBIKE/FOURWHEELED)")]
        public string vehicleType { get; set; }

        [Required]
        [Display(Name = "Is the Vehicle small?")]
        public bool isSmallSized { get; set; } //true- pequeno false-grande

        [Required]
        [Display(Name = "Is it destined for tourism?")]
        public bool isForTourism { get; set; } //true- turismo false-comercial

        [Required]
        [Display(Name = "What will be the vehicle's rental price per minute?")]
        public int pricePerMinute { get; set; }

        [Required]
        [Display(Name = "The vehicle's current battery percentage")]
        public int remainingBattery { get; set; } //0-100, carrega nas carstations
    }

    public class changeVehiclePriceViewModel
    {
        [Required]
        [Display(Name = "Target Vehicle's ID number")]
        public int vehicleID { get; set; }

        [Required]
        [Display(Name = "Vehicle's new price")]
        public int pricePerMinute { get; set; }
    }

    public class RemVehicleViewModel
    {
        [Required]
        [Display(Name = "Id of the vehicle to remove")]
        public int vehicleID { get; set; }
    }
}