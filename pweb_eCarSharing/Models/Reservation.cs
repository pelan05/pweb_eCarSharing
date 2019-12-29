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
        
        [ForeignKey("User")]
        public int UserID { get; set; }
        public virtual User User { get; set; }

        [ForeignKey("Vehicle")]
        public int VehicleID { get; set; }
        public virtual Vehicle Vehicle { get; set; }

        [ForeignKey("startCarStation")]
        public int idStationIdstart { get; set; }
        public virtual CarStation startCarStation  { get; set; }

        [ForeignKey("endCarStation")]
        public int idStationIdEnd { get; set; }
        public virtual CarStation endCarStation { get; set; }



        //em minutos
        //TOSO meter  duas variaveis para inicio e fim de reserva
        public int predictedUseTime { get; set; }

        public int predictedCost { get; set; }
    }
}