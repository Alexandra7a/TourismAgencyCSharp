using AgencyModel.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgencyPersistence.repository.interfaces
{
    public interface ITripRepository:IRepository<long,Trip>
    {
        public IEnumerable<Trip> findAllTripPlaceTime(String place, DateTime startTime, DateTime endTime);
    }
}
