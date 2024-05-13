using AgencyModel.model.dto;
using AgencyServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using TripNetworking;
using Utils;
using AgencyModel.model;
using AgencyNetworking.utils;
using System.IO;
using Google.Protobuf;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AgencyNetworking.protobuffprotocol
{
    internal class AgencyClientProtoWorker: IObserver
    {
        private IService service;
        private TcpClient connection;
        private NetworkStream stream;
       // private IFormatter formatter;
        private volatile bool connected;
        private Queue<Proto.Request> requests;


        public AgencyClientProtoWorker(IService service, TcpClient connection)
        {
            this.service = service;
            this.connection = connection;
            this.requests=new Queue<Proto.Request>();
            try
            {
                stream = connection.GetStream();
                // formatter = new BinaryFormatter();
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
                    Proto.Request request = Proto.Request.Parser.ParseDelimitedFrom(stream);
                    Proto.Response response = handleRequest(request);

                    if (response != null)
                    {
                        sendResponse(response);
                    }
                    else
                    {
                        lock (request)
                        {
                            requests.Enqueue(request);
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

        private Proto.Response handleRequest(Proto.Request request)
        {
            Proto.Response response = null;
            if (request.Type == Proto.Request.Types.RequestType.Login)
            {
                EmployeeDTO udto = ProtoUtils.getEmployeeDTO(request);
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
                        got = service.findUser(username, password, this);
                        Console.WriteLine(got.Value);
                        if (got.HasValue)
                        {
                            return ProtoUtils.createEmptyOkResponse();
                            //  return new Response.Builder().SetType(ResponseType.OK).Build();
                        }
                        else
                            return ProtoUtils.createErrorResponse("Username not found");
                    }

                }
                catch (Exception e)
                {
                    connected = false;
                    return ProtoUtils.createErrorResponse("Invalid username or password");
                }
            }

            if (request.Type == Proto.Request.Types.RequestType.Logout)
            {
                EmployeeDTO udto = ProtoUtils.getEmployeeDTO(request);
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
                        return ProtoUtils.createEmptyOkResponse();

                    }

                }
                catch (Exception e)
                {
                    connected = false;
                    return ProtoUtils.createErrorResponse(e.Message);
                }
            }

            if (request.Type == Proto.Request.Types.RequestType.FindAllTrips)
            {
                Console.WriteLine("FindTrips request ...");

                List<TripDTO> trips = new List<TripDTO>();
                try
                {
                    lock (service)
                    {
                        trips = (List<TripDTO>)service.getAllTrips();
                        Console.WriteLine("ASA AJUNGE IN WORKER TRIPS");
                        foreach(TripDTO t in trips)
                        {
                            Console.WriteLine(t);
                        }
                    }
                }
                catch (Exception e)
                {
                    return ProtoUtils.createErrorResponse("Error at find all trips request");
                }
                return ProtoUtils.createFindAllTripsResponse(trips);
            }

            if (request.Type == Proto.Request.Types.RequestType.GetReservations)
            {
                Console.WriteLine("Get reservations request ...");
                int reservationsNnumber = 0;
                try
                {
                    lock (service)
                    {
                        reservationsNnumber = service.getAllReservationsAt((long)request.Id);
                    }
                }
                catch (Exception e)
                {
                    return ProtoUtils.createErrorResponse("Error at find all number of reservations request");
                }
                return ProtoUtils.createNumberReservationsResponse(reservationsNnumber);
            }

            if (request.Type == Proto.Request.Types.RequestType.FindAllTrips)
            {
                Console.WriteLine("ClientsAll request ...");

                List<ClientDTO> clients = new List<ClientDTO>();
                try
                {
                    lock (service)
                    {
                        clients = (List<ClientDTO>)service.getAllClients();
                    }
                }
                catch (Exception e)
                {
                    return ProtoUtils.createErrorResponse("Error at find all clients request");
                }
                return ProtoUtils.createFindAllClientsResponse(clients);
            }

            if (request.Type == Proto.Request.Types.RequestType.FilterTrips)
            {
                Console.WriteLine("Find filtered trips request ...");

                List<TripDTO> trips = new List<TripDTO>();

                try
                {
                    lock (service)
                    {
                        TripFilterBy data = ProtoUtils.getTripFilterByDataFromRequest(request);

                        string placeToVisit = data.PlaceToVisit;
                        DateTime startTime = data.StartTime;
                        DateTime endTime = data.EndTime;
                        trips = (List<TripDTO>)service.getAllFilteredTripsPlaceTime(placeToVisit, startTime, endTime);
                    }
                }
                catch (Exception e)
                {
                    return ProtoUtils.createErrorResponse("Error at filter trips request");
                }
                return ProtoUtils.createFindAllTripsResponse(trips);
            }

            if (request.Type ==Proto.Request.Types.RequestType.ReserveTicket)
            {
                Console.WriteLine("reservation making request ...");

                try
                {
                    lock (service)
                    {
                        var r = ProtoUtils.getReservationFromRequest(request);
                        Optional<ReservationDTO> result = service.saveReservation(r.ClientName, r.PhoneNumber, r.NoSeats, r.Trip, r.responsibleEmployee, r.Client);
                        return ProtoUtils.createEmptyOkResponse();
                    }
                }
                catch (Exception e)
                {
                    return ProtoUtils.createErrorResponse("Error at reserving a ticket........");
                }
            }
            return ProtoUtils.createErrorResponse("Invalid request type");
        }

        private void sendResponse(Proto.Response response)
        {
            try
            {
                Console.WriteLine("sending response " + response);
                lock (stream)
                {

                    Console.WriteLine($"Send response ... {response}");
                    // formatter.Serialize(stream, response);
                    response.WriteDelimitedTo(stream);
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
            Proto.Response response = ProtoUtils.createUpdateResponse();
            sendResponse(response);
        }
    }
}
