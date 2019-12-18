using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace pweb_eCarSharing.Models
{
    public class Reservation
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int ReservationID { get; set; }
        
        [ForeignKey("User")]
        public int UserID { get; set; }
        
        [ForeignKey("Vehicle")]
        public int VehicleID { get; set; }
        
        [ForeignKey("CarStation")]
        public int startStation { get; set; }

        [ForeignKey("CarStation")]
        public int endStation { get; set; }

        //em minutos
        public int predictedUseTime { get; set; }

        public int predictedCost { get; set; }
    }
}