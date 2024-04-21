using Common.model;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.networking.response
{
    [Serializable]
    public class getAllFilteredTripsResponse :IResponse
    {
           public IEnumerable<Trip> tripList;
        public getAllFilteredTripsResponse(IEnumerable<Trip> trips) => tripList = trips;


    }

}
