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
        [Key]
        public int ReservationID { get; set; }
        
        [ForeignKey("UserNIB")]
        public int? UserNIBID { get; set; }
        public virtual UserNIB UserNIB { get; set; }

        [ForeignKey("Vehicle")]
        public int VehicleID { get; set; }
        public virtual Vehicle Vehicle { get; set; }

        [ForeignKey("startCarStation")]
        public int? idStationIdstart { get; set; }
        public virtual CarStation startCarStation  { get; set; }

        [ForeignKey("endCarStation")]
        public int? idStationIdEnd { get; set; }
        public virtual CarStation endCarStation { get; set; }



        //em minutos
        //TODO meter  duas variaveis para inicio e fim de reserva
        public int predictedUseTime { get; set; }

        public int predictedCost { get; set; }
    }
}