using AgencyModel.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgencyNetworking.rpcprotocol
{
    [Serializable]
    public class getAllClientsResponse :IResponse
    {
        public IEnumerable<Client> clientList;
        public getAllClientsResponse(IEnumerable<Client> trips) => clientList = trips;

    }
}
