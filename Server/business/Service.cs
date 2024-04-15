using Common.business;
using Common.model;
using Server.business;
using Server.repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.business
{
    internal class Service : IService
    {
        private TripDBRepository tripRepository;
        private ReservationDBRepository reservationRepository;
        private EmployeeDBRepository employeeRepository;
        private ClientDBRepository clientRepository;

        public Service(TripDBRepository repo, ReservationDBRepository repo2, EmployeeDBRepository repo3, ClientDBRepository repo4)
        {
            this.tripRepository = repo;
            this.reservationRepository = repo2;
            this.employeeRepository = repo3;
            this.clientRepository = repo4;
        }

        public IEnumerable<Trip> getAllTrip()
        {
            return tripRepository.findAll();
        }
        public Employee findUser(String user, String pass)
        {
            Employee result = employeeRepository.findOnebyUsername(user);
            if (result != null && result.Password.Equals(pass))
                return result;

            return null;

        }

        public int getAllReservationsAt(long id)
        {
            return reservationRepository.getAllReservationsAt(id);
        }

        public IEnumerable<Client> getAllClients()
        {
            return clientRepository.findAll();
        }

        public IEnumerable<Trip> getAllFilteredTris(string place, DateTime startDate, DateTime endDate)
        {
            return tripRepository.findAllTripPlaceTime(place, startDate, endDate);
        }

        public void saveReservation(string clientName, string phoneNumber, int noSeats, Trip trip, Employee responsibleEmployee, Client client)
        {
            Reservation reservation = new Reservation(clientName, phoneNumber, noSeats, trip, responsibleEmployee, client);
            if (!reservationRepository.save(reservation))
                throw new Exception("Not saved");

        }

    }
}
