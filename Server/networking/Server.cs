using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Common.business;

namespace Server.networking
{
    public class Server : ConcurrentAbstractServer
    {
        private IService service;
        private ServerWorker worker;

        public Server(string host, int port, IService service)
            : base(host, port)
        {
            this.service = service;
            Console.WriteLine("Server constructor...");
        }

        protected override Thread createWorker(TcpClient client)
        {
            worker = new ServerWorker(service, client);
            return new Thread(new ThreadStart(worker.run));
        }
    }
}
