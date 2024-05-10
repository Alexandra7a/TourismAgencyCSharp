using AgencyModel.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace AgencyPersistence.repository.interfaces
{
    public interface IReservationRepository: IRepository<long,Reservation>
    {
        public int getAllReservationsAt(long id);

    }
}
