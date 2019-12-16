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

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid VehicleID { get; set; }
        //foreign k
        public Guid vehicleOwner { get; set; }
        //fk
        public List<Guid> reservationHistory { get; set; }
        //fk
        public Guid currentStation { get; set; }

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