using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AgencyModel.model;
using AgencyModel.model.dto;
using Utils;


//todo MODIFICA DENUMIRILE SA SE POTRIVEASCA CU ALEA DIN JAVA
namespace AgencyServices
{
    public interface IService
    {
        public IEnumerable<TripDTO> getAllTrips();

        public Optional<Employee> findUser(String user, String pass,IObserver client);


        public int getAllReservationsAt(long id);


        public IEnumerable<ClientDTO> getAllClients();


        public IEnumerable<TripDTO> getAllFilteredTripsPlaceTime(string place, DateTime startDate, DateTime endDate);

        public Optional<ReservationDTO> saveReservation(string clientName, string phoneNumber, int noSeats, Trip trip, Employee responsibleEmployee, Client client);

        public void logout(Employee employee, IObserver client);
        public void addObserver(Employee employee,IObserver observer);

        public void removeObserver(IObserver observer);
    }
}
