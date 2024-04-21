using Common.model;
using Common.networking.request;

namespace Common.networking.request
{
    [Serializable]
    public class saveReservationRequest : IRequest
    {
        public string clientName;
        public string phoneNumber;
        public int noSeats;
        public Trip trip;
        public Employee responsibleEmployee;
        public Common.model.Client client;

        public saveReservationRequest(string clientName, string phoneNumber, int noSeats, Trip trip, Employee responsibleEmployee, Common.model.Client client)
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