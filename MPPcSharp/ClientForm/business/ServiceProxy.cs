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
namespace Client.business
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
                   /* if (response is NotifyResponse notifyResponse)
                    {
                        //this.client.notify(notifyResponse.donation);
                    }
                    else
                    {
                        lock (responses)
                        {
                            responses.Enqueue((IResponse)response);
                        }
                        _waitHandle.Set();
                    }*/
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
            throw new NotImplementedException();
        }

        public Employee findUser(string user, string pass)
        {
            sendRequest(new LoginRequest(user,pass));
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
            throw new NotImplementedException();
        }

        public IEnumerable<Common.model.Client> getAllClients()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Trip> getAllFilteredTris(string place, DateTime startDate, DateTime endDate)
        {
            throw new NotImplementedException();
        }

        public void saveReservation(string clientName, string phoneNumber, int noSeats, Trip trip, Employee responsibleEmployee, Common.model.Client client)
        {
            throw new NotImplementedException();
        }

        /* public Donation addDonation(decimal sum, long volunteerId, long donorId, long charityId)
         {
             sendRequest(new AddDonationRequest(sum, volunteerId, donorId, charityId));
             IResponse response = readResponse();
             if (response is ErrorResponse)
             {
                 throw new Exception("Login error");
             }
             else if (response is AddDonationResponse)
             {
                 return ((AddDonationResponse)response).donation;
             }
             else
             {
                 throw new Exception("Unknown server response");
             }
         }

         public Donor addDonor(string name, string phoneNumber, string address)
         {
             sendRequest(new AddDonorRequest(name, phoneNumber, address));
             IResponse response = readResponse();
             if (response is ErrorResponse)
             {
                 throw new Exception("Login error");
             }
             else if (response is AddDonorResponse)
             {
                 return ((AddDonorResponse)response).donor;
             }
             else
             {
                 throw new Exception("Unknown server response");
             }
         }

         public List<Charity> getAllCharities()
         {
             sendRequest(new GetAllCharitiesRequest());
             IResponse response = readResponse();
             if (response is ErrorResponse)
             {
                 throw new Exception("Login error");
             }
             else if (response is GetAllCharitiesResponse)
             {
                 return ((GetAllCharitiesResponse)response).charities;
             }
             else
             {
                 throw new Exception("Unknown server response");
             }
         }

         public Volunteer getByCredentials(string username, string password)
         {
             initializeConnection();
             sendRequest(new LoginRequest(username, password));
             IResponse response = readResponse();
             if (response is ErrorResponse)
             {
                 closeConnection();
                 throw new Exception("Login error");
             }
             else if (response is LoginResponse)
             {
                 return ((LoginResponse)response).volunteer;
             }
             else
             {
                 closeConnection();
                 throw new Exception("Unknown server response");
             }
         }

         public List<Donor> getFilteredDonors(string name)
         {
             sendRequest(new GetFilteredDonorsRequest(name));
             IResponse response = readResponse();
             if (response is ErrorResponse)
             {
                 throw new Exception("Login error");
             }
             else if (response is GetFilteredDonorsResponse)
             {
                 return ((GetFilteredDonorsResponse)response).donors;
             }
             else
             {
                 throw new Exception("Unknown server response");
             }
         }

         public decimal getSumForCharity(int charityId)
         {
             sendRequest(new GetSumForCharityRequest(charityId));
             IResponse response = readResponse();
             if (response is ErrorResponse)
             {
                 throw new Exception("Login error");
             }
             else if (response is GetSumForCharityResponse)
             {
                 return ((GetSumForCharityResponse)response).sum;
             }
             else
             {
                 throw new Exception("Unknown server response");
             }
         }

         public void addObserver(Volunteer volunteer, IObserver observer)
         {
             this.client = observer;
         }

         public void setClient(IObserver client)
         {
             this.client = client;
         }

         public void removeObserver(Volunteer volunteer, IObserver observer)
         {
             closeConnection();
             this.client = null;
         }
 */

    }
}
