using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgencyModel.model.dto
{
    [Serializable]
    public class TripFilterBy
    {
        public string PlaceToVisit { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        public TripFilterBy(string placeToVisit, DateTime startTime, DateTime endTime)
        {
            PlaceToVisit = placeToVisit;
            StartTime = startTime;
            EndTime = endTime;
        }
    }

}
