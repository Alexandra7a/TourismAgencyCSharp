using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Common.business;
using Common.model;
using Common.networking.request;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using Common.networking.response;
using Common.networking.response;

#pragma warning disable SYSLIB0011


/// to do
namespace ClientForm.business
{
    internal class ServiceProxy : IService
    {
        private string host;
        private int port;
        private IObserver client;
        private NetworkStream stream;
        private IFormatter formatter;
        private TcpClient connection;
        private Queue<IResponse> responses;
        private volatile bool finished;
        private EventWaitHandle _waitHandle;

        public ServiceProxy(string host, int port)
        {
            this.host = host;
            this.port = port;
            responses = new Queue<IResponse>();

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

        public virtual void run()
        {
            while (!finished)
            {
                try
                {
                    object response = formatter.Deserialize(stream);
                    Console.WriteLine("response received " + response);
                    if (response is NotifyResponse notifyResponse)
                    {
                        this.client.notify(); ///// aici notific clientii ca s-a schimbat lista 
                    }
                    else
                    {
                        lock (responses)
                        {
                            responses.Enqueue((IResponse)response);
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

        private void sendRequest(IRequest request)
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

        private IResponse readResponse()
        {
            IResponse response = null;
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

        public IEnumerable<Trip> getAllTrip()
        {
            sendRequest(new FindAllTripsRequest());
            IResponse response = readResponse();
            if (response is ErrorResponse)
            {
                throw new Exception("Trips not retrieved error");
            }
            else
            {
                return ((FindAllTripsResponse)response).tripList;
            }
            throw new NotImplementedException();
        }

        public Employee findUser(string user, string pass)
        {
            initializeConnection();
            sendRequest(new LoginRequest(user, pass));
            IResponse response = readResponse();
            if (response is ErrorResponse)
            {
                throw new Exception("Login error");
            }
            else if (response is LoginResponse)
            {
                return ((LoginResponse)response).employee;
            }
            else
            {
                throw new Exception("Unknown server response");
            }
        }

        public int getAllReservationsAt(long id)
        {
            sendRequest(new getAllReservationsAtRequest(id));
            IResponse response = readResponse();
            if (response is ErrorResponse)
            {
                throw new Exception("getAllReservationsAt error");
            }
            else
            {
                return ((getAllReservationsAtResponse)response).no;
            }
        }

        public IEnumerable<Client> getAllClients()
        {
            sendRequest(new getAllClientsRequest());
            IResponse response = readResponse();
            if (response is ErrorResponse)
            {
                throw new Exception("get all CLients error");
            }
            else
            {
                return ((getAllClientsResponse)response).clientList;
            }
        }

        public IEnumerable<Trip> getAllFilteredTris(string place, DateTime startDate, DateTime endDate)
        {
            sendRequest(new getAllFilteredTripsRequest(place, startDate, endDate));
            IResponse response = readResponse();
            if (response is ErrorResponse)
            {
                throw new Exception("get filtered Trips error");
            }
            else
            {
                return ((getAllFilteredTripsResponse)response).tripList;
            }
            throw new NotImplementedException();
        }

        public bool saveReservation(string clientName, string phoneNumber, int noSeats, Trip trip, Employee responsibleEmployee, Client client)
        {

            sendRequest(new saveReservationRequest(clientName, phoneNumber, noSeats, trip, responsibleEmployee, client));
            IResponse response = readResponse();
            if (response is ErrorResponse)
            {
                throw new Exception("reservation not made");
            }
            return true;
        }
        public void logOutClicked()
        {
            /*initializeConnection();
            sendRequest(new LoginRequest(user, pass));
            IResponse response = readResponse();
            if (response is ErrorResponse)
            {
                throw new Exception("Login error");
            }
            else if (response is LoginResponse)
            {
                return ((LoginResponse)response).employee;
            }
            else
            {
                throw new Exception("Unknown server response");
            }*/
        }

        public void addObserver( IObserver observer)
        {
            client = observer;
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
    }
}
