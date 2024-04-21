using Common.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.networking.response
{
    [Serializable]
    public class ReservationMadeResponse
    {
        public Reservation reservation;
        public ReservationMadeResponse(Reservation reservation)
        {
            this.reservation = reservation;
        }
    }
}
