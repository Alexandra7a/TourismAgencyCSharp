using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.model;

namespace Common.business
{
    public interface IService
    {
        public IEnumerable<Trip> getAllTrip();

        public Employee findUser(String user, String pass);


        public int getAllReservationsAt(long id);


        public IEnumerable<Client> getAllClients();


        public IEnumerable<Trip> getAllFilteredTris(string place, DateTime startDate, DateTime endDate);

        public void saveReservation(string clientName, string phoneNumber, int noSeats, Trip trip, Employee responsibleEmployee, Client client);
        
    }
}
