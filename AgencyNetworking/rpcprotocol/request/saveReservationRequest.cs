using AgencyModel.model;

namespace AgencyNetworking.rpcprotocol
{
    [Serializable]
    public class saveReservationRequest : IRequest
    {
        public string clientName;
        public string phoneNumber;
        public int noSeats;
        public Trip trip;
        public Employee responsibleEmployee;
        public Client client;

        public saveReservationRequest(string clientName, string phoneNumber, int noSeats, Trip trip, Employee responsibleEmployee, Client client)
        {
            this.clientName = clientName;
            this.phoneNumber = phoneNumber;
            this.noSeats = noSeats;
            this.trip = trip;
            this.responsibleEmployee = responsibleEmployee;
            this.client = client;
        }
    }
}