using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using AgencyServices;
using TripNetworking;
using AgencyModel.model.dto;
using AgencyModel.model;
using Utils;

namespace AgencyNetworking.rpcprotocol
{
    public class AgencyClientRpcWorker : IObserver
    {
        private IService service;
        private TcpClient connection;
        private NetworkStream stream;
        private IFormatter formatter;
        private volatile bool connected;
        private Queue<Request> requests;


        public AgencyClientRpcWorker(IService service, TcpClient connection)
        {
            this.service = service;
            this.connection = connection;
            requests = new Queue<Request>();
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

/*        public void notify()
        {
            sendResponse(new NotifyResponse());
        }*/

        public void reservationMade()
        {
            throw new NotImplementedException();
        }

        public virtual void run()
        {
            while (connected)
            {
                try
                {
#pragma warning disable SYSLIB0011 // Type or member is obsolete
                    object request = formatter.Deserialize(stream);
#pragma warning restore SYSLIB0011 // Type or member is obsolete
                    object response = handleRequest((Request)request);

                    if (response != null)
                    {
                        sendResponse((Response)response);
                    }
                    else
                    {
                        lock (request)
                        {
                            requests.Enqueue((Request)request);
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

        private Response handleRequest(Request request)
        {
            Response response = null;
            if (request.Type==RequestType.LOGIN)
            {
                EmployeeDTO udto = (EmployeeDTO)request.Data;
                Employee user = DTOUtils.GetFromDTO(udto);
                Console.WriteLine("Login request ...");
                string username = user.Username;
                string password = user.Password;
                Console.WriteLine(username);
                Console.WriteLine(password);

                Optional<Employee> got;
                try
                {
                    lock (service)
                    {
                        got=service.findUser(username, password,this);
                        Console.WriteLine(got.Value);
                        if (got.HasValue)
                        {
                            return new Response.Builder().SetType(ResponseType.OK).Build();
                        }
                        else
                            return new Response.Builder().SetType(ResponseType.ERROR).SetData("Username not found").Build();
                    }

                }
                catch (Exception e)
                {
                    connected = false;
                    return new Response.Builder().SetType(ResponseType.ERROR).SetData("Invalid username or password").Build();
               }
            }
            if (request.Type == RequestType.LOGOUT)
            {
                EmployeeDTO udto = (EmployeeDTO)request.Data;
                Employee user = DTOUtils.GetFromDTO(udto);
                Console.WriteLine("Logout request ...");
                string username = user.Username;
                string password = user.Password;
                Console.WriteLine(username);
                Console.WriteLine(password);

                try
                {
                    lock (service)
                    {
                        service.logout(user, this);
                        connected = false;
                        return new Response.Builder().SetType(ResponseType.OK).Build();
                       
                    }

                }
                catch (Exception e)
                {
                    connected = false;
                    return new Response.Builder().SetType(ResponseType.ERROR).SetData(e).Build();
                }
            }
            if (request.Type==RequestType.FIND_ALL_TRIPS)
             {
                 Console.WriteLine("FindTrips request ...");

                 IEnumerable<TripDTO> trips = new List<TripDTO>();
                 try
                 {
                     lock (service)
                     {
                        trips = (IEnumerable<TripDTO>)service.getAllTrips();
                     }
                 }
                 catch (Exception e)
                 {
                    return new Response.Builder().SetType(ResponseType.ERROR).SetData("Error at find all trips request").Build();
                }
                return new Response.Builder().SetType(ResponseType.OK).SetData(trips).Build();
             }

             if (request.Type== RequestType.GET_RESERVATIONS)
             {
                 Console.WriteLine("Get reservations request ...");
                 int reservationsNnumber = 0;
                 try
                 {
                     lock (service)
                     {
                         reservationsNnumber = service.getAllReservationsAt((long)request.Data);
                     }
                 }
                 catch (Exception e)
                 {
                    return new Response.Builder().SetType(ResponseType.ERROR).SetData("Error at find all number of reservations request").Build();
                }
                return new Response.Builder().SetType(ResponseType.OK).SetData(reservationsNnumber).Build();
             }

             if (request.Type==RequestType.FIND_ALL_CLIENTS)
             {
                 Console.WriteLine("ClientsAll request ...");

                 IEnumerable<ClientDTO> clients = new List<ClientDTO>();
                 try
                 {
                     lock (service)
                     {
                         clients = (IEnumerable<ClientDTO>)service.getAllClients();
                     }
                 }
                 catch (Exception e)
                 {
                     return new Response.Builder().SetType(ResponseType.ERROR).SetData("Error at find all clients request").Build();
                 }
                 return new Response.Builder().SetType(ResponseType.OK).SetData(clients).Build();
             }

             if (request.Type==RequestType.FILTER_TRIPS)
             {
                 Console.WriteLine("Find filtered trips request ...");

                 IEnumerable<TripDTO> trips = new List<TripDTO>();
                 
                 try
                 {
                     lock (service)
                     {
                        TripFilterBy data = (TripFilterBy)request.Data;

                        string placeToVisit = data.PlaceToVisit;
                        DateTime startTime = data.StartTime;
                        DateTime endTime = data.EndTime;
                        trips = service.getAllFilteredTripsPlaceTime(placeToVisit, startTime, endTime);
                     }
                 }
                 catch (Exception e)
                 {
                    return new Response.Builder().SetType(ResponseType.ERROR).SetData("Error at filter trips request").Build();
                }
                return new Response.Builder().SetType(ResponseType.OK).SetData(trips).Build();
            }
            if (request.Type==RequestType.RESERVE_TICKET)
             {
                 Console.WriteLine("reservation making request ...");

                 try
                 {
                     lock (service)
                     {
                        var r = (ReservationDTO)request.Data;
                        Optional<ReservationDTO> result = service.saveReservation(r.ClientName, r.PhoneNumber,r.NoSeats, r.Trip,r.responsibleEmployee, r.Client);
                        return new Response.Builder().SetType(ResponseType.OK).Build();
                    }
                }
                 catch (Exception e)
                 {
                    return new Response.Builder().SetType(ResponseType.ERROR).SetData("Error at reserving a ticket........").Build();
                }
            }
            return new Response.Builder().SetType(ResponseType.ERROR).SetData("Invalid request type").Build();
        }

        private void sendResponse(Response response)
        {
            try
            {
                Console.WriteLine("sending response " + response);
                lock (stream)
                {
#pragma warning disable SYSLIB0011 // Type or member is obsolete
                    formatter.Serialize(stream, response);
#pragma warning restore SYSLIB0011 // Type or member is obsolete
                    stream.Flush();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        
        }

        public void reservationUpdate()
        {
            Console.WriteLine("Reservation update in worker ...");
            Response response = new Response.Builder().SetType(ResponseType.UPDATE).SetData(null).Build();
            sendResponse(response);
        }
    }
}
