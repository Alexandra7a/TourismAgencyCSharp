using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AgencyModel.model;
namespace AgencyServices
{
    public interface IObserver
    {
        public void reservationUpdate();
    }
}
