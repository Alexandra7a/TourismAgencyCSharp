using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgencyModel.model
{
    [Serializable]

    public class Reservation : Entity<long>
    {
        public string ClientName { get; set; }
        public string PhoneNumber{ get; set; }
        public int NoSeats { get; set; }
        public Trip Trip { get; set; }
        public Employee responsibleEmployee { get; set; }
        public Client Client { get; set; }

        public Reservation(string clientName, string phoneNumber, int noSeats, Trip trip, Employee employee, Client client)
        {
            ClientName = clientName;
            PhoneNumber = phoneNumber;
            NoSeats = noSeats;
            Trip = trip;
            responsibleEmployee = employee;
            Client = client;
        }
    }
}
