using Common.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.networking.response
{
    [Serializable]
    public class FindAllTripsResponse : IResponse
    {
        public IEnumerable<Trip> tripList;
        public FindAllTripsResponse(IEnumerable<Trip> trips) => tripList = trips;
        

    }
}
