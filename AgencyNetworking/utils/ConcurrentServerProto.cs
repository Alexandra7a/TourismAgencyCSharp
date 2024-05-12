using AgencyNetworking.protobuffprotocol;
using AgencyNetworking.utils;
using AgencyServices;
using System;
using System.Net.Sockets;
using System.Threading;


namespace AgencyNetworking.utils
{
    public class ConcurrentServerProto : ConcurrentAbstractServer
    {
        private IService server;
        private AgencyClientProtoWorker worker;
        public ConcurrentServerProto(string host, int port, IService server) : base(host, port)
        {
            this.server = server;
            Console.WriteLine("PROTO ConcurrentServer...");
        }
        protected override Thread createWorker(TcpClient client)
        {
            worker = new AgencyClientProtoWorker(server, client);
            return new Thread(new ThreadStart(worker.run));
        }

    }
}