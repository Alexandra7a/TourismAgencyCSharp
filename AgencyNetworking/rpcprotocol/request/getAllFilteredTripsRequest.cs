using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgencyNetworking.rpcprotocol
{
    [Serializable]
    public class getAllFilteredTripsRequest : IRequest
    {
        public string place;
        public DateTime startDate, endDate;
        public getAllFilteredTripsRequest(string place, DateTime startDate, DateTime endDate) {
        this.place = place;
        this.startDate = startDate;
        this.endDate = endDate;
        }
    }
}
