using AgencyModel.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgencyNetworking.rpcprotocol
{
    [Serializable]
    public class FindAllTripsResponse : IResponse
    {
        public IEnumerable<Trip> tripList;
        public FindAllTripsResponse(IEnumerable<Trip> trips) => tripList = trips;
        

    }
}
