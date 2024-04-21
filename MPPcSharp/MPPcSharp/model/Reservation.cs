using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TemaMPPcSharp.Model;

namespace Lab2MPP.Model
{
    internal class Reservation : Entity<long>
    {
        public string ClientName { get; set; }
        public string PhoneNumber{ get; set; }
        public long NoSeats { get; set; }
        public Trip Trip { get; set; }
        public Employee Employee { get; set; }
        public Client Client { get; set; }

        public Reservation(string clientName, string phoneNumber, long noSeats, Trip trip, Employee employee, Client client)
        {
            ClientName = clientName;
            PhoneNumber = phoneNumber;
            NoSeats = noSeats;
            Trip = trip;
            Employee = employee;
            Client = client;
        }
    }
}
