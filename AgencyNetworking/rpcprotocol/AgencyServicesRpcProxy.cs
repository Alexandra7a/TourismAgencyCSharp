using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using AgencyServices;
using AgencyModel.model;
using TripNetworking;
using AgencyModel.model.dto;
using Utils;
#pragma warning disable SYSLIB0011

namespace AgencyNetworking.rpcprotocol
{
    public class AgencyServicesRpcProxy: IService
    {
        private string host;
        private int port;
        private IObserver client;
        private NetworkStream stream;
        private IFormatter formatter;
        private TcpClient connection;
        private Queue<Response> responses;
        private volatile bool finished;
        private EventWaitHandle _waitHandle;

        public AgencyServicesRpcProxy(string host, int port)
        {
            this.host = host;
            this.port = port;
            responses = new Queue<Response>();

        }

        private void initializeConnection()
        {
            try
            {
                connection = new TcpClient(host, port);
                stream = connection.GetStream();
                formatter = new BinaryFormatter();
                finished = false;
                _waitHandle = new AutoResetEvent(false);
                startReader();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
        }

        private void closeConnection()
        {
            finished = true;
            try
            {
                stream.Close();
                connection.Close();
                _waitHandle.Close();
                client = null;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
        }

        private void startReader()
        {
            Thread tw = new Thread(run);
            tw.Start();
        }
        private bool IsUpdate(Response response)
        {
            return response.Type == ResponseType.UPDATE;
        }


        private void HandleUpdate(Response response)
        {
            ///notify the specific client in updating itself 
            if (response.Type == ResponseType.UPDATE) ///maybe there are more different types of updates, so the response helps checking them
            {
                client.reservationUpdate();
            }
        }
        public virtual void run()
        {
            while (!finished)
            {
                try
                {
                    Response response =(Response) formatter.Deserialize(stream); // this might be obsolite ...
                    Console.WriteLine("response received " + response);


                    if (IsUpdate(response))
                    {
                        this.HandleUpdate(response);
                    }
                    else
                    {
                        lock (responses)
                        {
                            responses.Enqueue((Response)response);
                        }
                        _waitHandle.Set();
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Reading error " + e);
                }
            }
        }

        private void sendRequest(Request request)
        {
            try
            {
                formatter.Serialize(stream, request);
                stream.Flush();
            }
            catch (Exception e)
            {
                throw new Exception("Error sending object " + e);
            }
        }

        private Response readResponse()
        {
            Response response = null;
            try
            {
                _waitHandle.WaitOne();
                lock (responses)
                {
                    //Monitor.Wait(responses);
                    response = responses.Dequeue();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
            return response;
        }

      

    public Optional<Employee> findUser(string user, string pass,IObserver client)
        {
             initializeConnection();
            EmployeeDTO employeeDTO = new EmployeeDTO(user, pass);

            Request request = new Request.Builder().SetType(RequestType.LOGIN).SetData(employeeDTO).Build();
            sendRequest(request);
            Response response = readResponse();
             
            if (response.Type== ResponseType.OK)
            {
                this.client = client;
                return Optional<Employee>.Of(DTOUtils.GetFromDTO(employeeDTO));
            }
            if (response.Type==ResponseType.ERROR)
            {
                closeConnection();
                string err = (string)response.Data;
                throw new Exception(err);
            }
            return Optional<Employee>.Empty();
        }

        public IEnumerable<TripDTO> getAllTrips()
        {
            Request request = new Request.Builder().SetType(RequestType.FIND_ALL_TRIPS).Build();

            sendRequest(request);
            Response response = readResponse();
            if (response.Type == ResponseType.ERROR)
            {
                throw new Exception("Error: trips not retrieved");
            }
            else
            {
                return (IEnumerable<TripDTO>)response.Data;
            }
            throw new NotImplementedException();
        }

        public int getAllReservationsAt(long id)
        {
            Request request = new Request.Builder().SetType(RequestType.GET_RESERVATIONS).SetData(id).Build();

            sendRequest(request); Response response = readResponse();
            if (response.Type == ResponseType.ERROR)
            {
                throw new Exception("getAllReservationsAt error");
            }
            else
            {
                return (int)response.Data;
            }
            throw new NotImplementedException();

        }



        public IEnumerable<TripDTO> getAllFilteredTripsPlaceTime(string place, DateTime startDate, DateTime endDate)
        {
            TripFilterBy filteredObj = new TripFilterBy(place, startDate, endDate);
            Request request = new Request.Builder().SetType(RequestType.FILTER_TRIPS).SetData(filteredObj).Build();
            sendRequest(request);
            Response response = readResponse();
            if (response.Type == ResponseType.ERROR)
            {
                throw new Exception("Error at getting filtered Trips");
            }
            else
            {
                return (IEnumerable<TripDTO>)response.Data;
            }
            throw new NotImplementedException();
        }


        IEnumerable<ClientDTO> IService.getAllClients()
        {
            Request request = new Request.Builder().SetType(RequestType.FIND_ALL_CLIENTS).Build();
            sendRequest(request); 
            Response response = readResponse();
            if (response.Type == ResponseType.ERROR)
            {
                throw new Exception("get all CLients error");
            }
            else
            {
                return (IEnumerable<ClientDTO>)response.Data;
            }
            throw new NotImplementedException();
        }



        public Optional<ReservationDTO> saveReservation(string clientName, string phoneNumber, int noSeats, Trip trip, Employee responsibleEmployee, Client client)
        {

            ReservationDTO rDto=new ReservationDTO(clientName,phoneNumber,noSeats,trip,responsibleEmployee,client);
            Request request = new Request.Builder().SetType(RequestType.RESERVE_TICKET).SetData(rDto).Build();
            sendRequest(request);
            Response response = readResponse();
            if (response.Type == ResponseType.ERROR)
            {
                throw new Exception("reservation not made");
            }
            return Optional<ReservationDTO>.Empty();
        }
      
        public void addObserver(Employee employee, IObserver observer)
        {
            this.client = observer;
        }

        public void setClient(IObserver client)
        {
            this.client = client;
        }

        public void removeObserver(Reservation reservation, IObserver observer)
        {
            closeConnection();
            client = null;
        }

        public void removeObserver(IObserver observer)
        {
            throw new NotImplementedException();
        }


        public void logout(Employee employee, IObserver client)
        {
            initializeConnection();
            EmployeeDTO employeeDTO = new EmployeeDTO(employee.Username, employee.Password);

            Request request = new Request.Builder().SetType(RequestType.LOGOUT).SetData(employeeDTO).Build();
            sendRequest(request);
            Response response = readResponse();
            if (response.Type == ResponseType.ERROR)
            {
                
                string err = (string)response.Data;
                throw new Exception(err);
            }
            if (response.Type == ResponseType.OK)
            {
                closeConnection();
            }
        }
    }
}
