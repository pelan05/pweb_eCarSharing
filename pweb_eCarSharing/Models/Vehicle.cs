using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace pweb_eCarSharing.Models
{
    public class Vehicle
    {
        public enum VehicleType
        {
            [Description("Scooter")]
            SCOOTER,            //trotinete
            [Description("Bicicle")]
            BIKE,           //biciclete
            [Description("Motorbike")]
            MOTORBIKE,      //motociclo
            [Description("Four Wheeled Vehicle")]
            FOURWHEELED     //4 rodas
        };

        [Key]
        public int VehicleID { get; set; }

        [ForeignKey("User")]
        public int? vehicleOwner { get; set; }
        public virtual  User User { get; set; }

        /*[ForeignKey("Reservation")]
        public List<int> reservationHistory { get; set; }
        public virtual Reservation Reservation { get; set; }*/
        
        [ForeignKey("CarStation")]
        public int? currentStation { get; set; }
        public virtual CarStation CarStation { get; set; }

        [Required]
        public string vehicleType { get; set; }

        public bool isSmallSized { get; set; } //true- pequeno false-grande

        public bool isForTourism { get; set; } //true- turismo false-comercial

        [Required]
        public bool inUse { get; set; }

        [Required]
        public float pricePerMinute { get; set; }

        [Range(0, 100)]
        public int remainingBattery { get; set; } //0-100, carrega nas carstations

    }
}