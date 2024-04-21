using Common.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.networking.response
{
    [Serializable]
    public class getAllClientsResponse :IResponse
    {
        public IEnumerable<Client> clientList;
        public getAllClientsResponse(IEnumerable<Client> trips) => clientList = trips;

    }
}
