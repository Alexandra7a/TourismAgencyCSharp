using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
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
        private Queue<IRequest> requests;


        public ServerWorker(IService service, TcpClient connection)
        {
            this.service = service;
            this.connection = connection;
            requests = new Queue<IRequest>();
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

        public void notify()
        {
            sendResponse(new NotifyResponse());
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
                    else
                    {
                        lock (request)
                        {
                            requests.Enqueue((IRequest)request);
                        }
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
                this.service.addObserver(got, this);
                return new LoginResponse(got);
            }
            if (request is FindAllTripsRequest findTrips)
            {
                Console.WriteLine("FindTrips request ...");
               
                IEnumerable<Trip> trips=new List<Trip>();
                try
                {
                    lock (service)
                    {
                        trips = service.getAllTrip();
                    }
                }
                catch (Exception e)
                {
                    connected = false;
                    return new ErrorResponse(e.Message);
                }
                return new FindAllTripsResponse(trips);
            }

            if (request is getAllReservationsAtRequest reservation)
            {
                Console.WriteLine("Reserve request ...");
                int resnumber=0;
                try
                {
                    lock (service)
                    {
                        resnumber = service.getAllReservationsAt(((getAllReservationsAtRequest)reservation).id);
                    }
                }
                catch (Exception e)
                {
                    connected = false;
                    return new ErrorResponse(e.Message);
                }
                return new getAllReservationsAtResponse(resnumber);
            }

            if (request is getAllClientsRequest  getClients)
            {
                Console.WriteLine("ClientsAll request ...");

                IEnumerable<Common.model.Client> clients = new List<Common.model.Client>();
                try
                {
                    lock (service)
                    {
                        clients = service.getAllClients();
                    }
                }
                catch (Exception e)
                {
                    connected = false;
                    return new ErrorResponse(e.Message);
                }
                return new getAllClientsResponse(clients);
            }

            if (request is getAllFilteredTripsRequest findTripsfiletred)
            {
                Console.WriteLine("FindTrips request ...");

                IEnumerable<Trip> trips = new List<Trip>();
                try
                {
                    lock (service)
                    {
                        
                        trips = service.getAllFilteredTris(findTripsfiletred.place, findTripsfiletred.startDate,findTripsfiletred.endDate);
                    }
                }
                catch (Exception e)
                {
                    connected = false;
                    return new ErrorResponse(e.Message);
                }
                return new getAllFilteredTripsResponse(trips);
            }
            if (request is saveReservationRequest res)
            {
                Console.WriteLine("reservation making request ...");

                
                try
                {
                    lock (service)
                    {
                        bool result=service.saveReservation(res.clientName,res.phoneNumber,res.noSeats,res.trip,res.responsibleEmployee,res.client);
                        return new saveReservationResponse();
                    }
                }
                catch (Exception e)
                {
                    connected = false;
                    return new ErrorResponse(e.Message);
                }
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
