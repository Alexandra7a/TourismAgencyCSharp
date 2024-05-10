using AgencyModel.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgencyNetworking.rpcprotocol
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
