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
              //  this.service.addObserver(got, this);
                return new LoginResponse(got);
            }
           /* if (request is AddDonationRequest addDonationRequest)
            {
                Console.WriteLine("AddDonationRequest request");
                Decimal sum = addDonationRequest.sum;
                long volunteerId = addDonationRequest.volunteerId;
                long charityId = addDonationRequest.charityId;
                long donorId = addDonationRequest.donorId;
                Donation got;
                try
                {
                    lock (service)
                    {
                        got = service.addDonation(sum, volunteerId, donorId, charityId);
                    }
                }
                catch (Exception e)
                {
                    connected = false;
                    return new ErrorResponse(e.Message);
                }
                return new AddDonationResponse(got);
            }
            if (request is AddDonorRequest addDonorRequest)
            {
                Console.WriteLine("Add donor request");
                string name = addDonorRequest.name;
                string phoneNumber = addDonorRequest.phoneNumber;
                string address = addDonorRequest.address;
                Donor got;
                try
                {
                    lock (service)
                    {
                        got = this.service.addDonor(name, phoneNumber, address);
                    }
                }
                catch (Exception e)
                {
                    connected = false;
                    return new ErrorResponse(e.Message);
                }
                return new AddDonorResponse(got);
            }

            if (request is GetAllCharitiesRequest)
            {
                Console.WriteLine("Get all charities request");
                List<Charity> got;
                try
                {
                    lock (service)
                    {
                        got = service.getAllCharities();
                    }
                }
                catch (Exception e)
                {
                    connected = false;
                    return new ErrorResponse(e.Message);
                }
                return new GetAllCharitiesResponse(got);
            }

            if (request is GetFilteredDonorsRequest getFilteredDonorsRequest)
            {
                Console.WriteLine("Get filtered donors request");
                string name = getFilteredDonorsRequest.name;
                List<Donor> got;
                try
                {
                    lock (service)
                    {
                        got = service.getFilteredDonors(name);
                    }
                }
                catch (Exception e)
                {
                    connected = false;
                    return new ErrorResponse(e.Message);
                }
                return new GetFilteredDonorsResponse(got);
            }

            if (request is GetSumForCharityRequest getSumForCharityRequest)
            {
                Console.WriteLine("Get sum for charity request");
                long charityId = getSumForCharityRequest.charityId;
                Decimal got;
                try
                {
                    lock (service)
                    {
                        got = service.getSumForCharity((int)charityId);
                    }
                }
                catch (Exception e)
                {
                    connected = false;
                    return new ErrorResponse(e.Message);
                }
                return new GetSumForCharityResponse(got);
            }*/

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

       /* public void notify(Donation newDonation)
        {
            sendResponse(new NotifyResponse(newDonation));
        }*/
    }
}
