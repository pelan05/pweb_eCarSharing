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
        public Guid ReservationID { get; set; }
        //foreign key
        public Guid UserID { get; set; }
        //fk
        public Guid VehicleID { get; set; }
        //fk
        public Guid startStation { get; set; }
        //fk
        public Guid endStation { get; set; }

        //em minutos
        public int predictedUseTime { get; set; }

        public int predictedCost { get; set; }
    }
}