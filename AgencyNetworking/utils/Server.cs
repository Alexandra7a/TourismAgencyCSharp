using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using AgencyServices;
using AgencyNetworking.rpcprotocol;

namespace AgencyNetworking.utils
{
    public class Server : ConcurrentAbstractServer
    {
        private IService service;
        private AgencyClientRpcWorker worker;

        public Server(string host, int port, IService service)
            : base(host, port)
        {
            this.service = service;
            Console.WriteLine("Server constructor...");
        }

        protected override Thread createWorker(TcpClient client)
        {
            worker = new AgencyClientRpcWorker(service, client);
            return new Thread(new ThreadStart(worker.run));
        }
    }
}
