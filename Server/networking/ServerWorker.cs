using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using Common.business;
using Common.model;
using Common.networking.request;
using Common.networking.response;

#pragma warning disable SYSLIB0011

namespace Server.networking
{
    public class ServerWorker : IObserver
    {
        private IService service;
        private TcpClient connection;
        private NetworkStream stream;
        private IFormatter formatter;
        private volatile bool connected;

        public ServerWorker(IService service, TcpClient connection)
        {
            this.service = service;
            this.connection = connection;
            try
            {
                stream = connection.GetStream();
                formatter = new BinaryFormatter();
                connected = true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
        }

        public void notify(Reservation newDonation)
        {
            throw new NotImplementedException();
        }

        public virtual void run()
        {
            while (connected)
            {
                try
                {
                    object request = formatter.Deserialize(stream);
                    object response = handleRequest((IRequest)request);
                    if (response != null)
                    {
                        sendResponse((IResponse)response);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
            try
            {
                stream.Close();
                connection.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error " + e);
            }
        }

        private IResponse handleRequest(IRequest request)
        {
            IResponse response = null;
            if (request is LoginRequest loginRequest)
            {
                Console.WriteLine("Login request ...");
                string username = loginRequest.username;
                string password = loginRequest.password;
                Employee got;
                try
                {
                    lock (service)
                    {
                        got = service.findUser(username, password);
                    }
                }
                catch (Exception e)
                {
                    connected = false;
                    return new ErrorResponse(e.Message);
                }
                return new LoginResponse(got);
            }
           
            return new ErrorResponse("Unknown request");
        }

        private void sendResponse(IResponse response)
        {
            Console.WriteLine("sending response " + response);
            lock (stream)
            {
                formatter.Serialize(stream, response);
                stream.Flush();
            }
        }
    }
}
