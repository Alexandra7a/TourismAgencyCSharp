using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AgencyPersistence.repository;
using AgencyModel.model;
using AgencyServices;
using AgencyPersistence.repository.interfaces;
using Utils;
using AgencyModel.model.dto;

namespace AgencyServer.service
{
    internal class Service : IService
    {
        private ITripRepository tripRepository;
        private IReservationRepository reservationRepository;
        private IEmployeeRepository employeeRepository;
        private IClientRepository clientRepository;
        private readonly IDictionary<string, IObserver> loggedClients;

        public Service(ITripRepository repo, IReservationRepository repo2, IEmployeeRepository repo3, IClientRepository repo4)
        {
            this.tripRepository = repo;
            this.reservationRepository = repo2;
            this.employeeRepository = repo3;
            this.clientRepository = repo4;

            loggedClients=new Dictionary<string, IObserver>();
        }

      
        /*THE LOG IN**/
        public Optional<Employee> findUser(String user, String pass,IObserver client)
        {
            Console.WriteLine("Entered Service IMplementation------------");
            Optional<Employee> result = employeeRepository.findOnebyUsername(user);
            Console.WriteLine("result",result.Value);

            if (result.HasValue && result.Value.Password.Equals(pass))
            {
                if (loggedClients.ContainsKey(user)) {
                    throw new Exception("User already logged!");
                }
                loggedClients.Add(user, client); // ADDED FOR THE NOTIFY PURPOSES
               
                    return Optional<Employee>.Of(result.Value);
            }
            return Optional<Employee>.Empty();

        }
        public IEnumerable<TripDTO> getAllTrips()
        {
            IEnumerable<Trip> trips = tripRepository.findAll();
            List<TripDTO> tripsDTO = new List<TripDTO>();
            foreach (Trip trip in trips)
            {
                tripsDTO.Add(DTOUtils.GetDTO(trip));
            }
            return tripsDTO;
        }


        public int getAllReservationsAt(long id)
        {
            return reservationRepository.getAllReservationsAt(id);

        }

        IEnumerable<ClientDTO> IService.getAllClients()
        {
            IEnumerable<Client> clients = clientRepository.findAll();
            List<ClientDTO> clientsDTO = new List<ClientDTO>();
            foreach (Client cli in clients)
            {
                clientsDTO.Add(DTOUtils.GetDTO(cli));
            }
            return clientsDTO;
        }

        public IEnumerable<TripDTO> getAllFilteredTripsPlaceTime(string place, DateTime startDate, DateTime endDate)
        {
            IEnumerable<Trip> trips=tripRepository.findAllTripPlaceTime(place, startDate, endDate);
            List<TripDTO> tripsDTO = new List<TripDTO>();
            foreach (Trip trip in trips)
            {
                tripsDTO.Add(DTOUtils.GetDTO(trip));
            }
            return tripsDTO;
        }

        public Optional<ReservationDTO> saveReservation(string clientName, string phoneNumber, int noSeats, Trip trip, Employee responsibleEmployee, Client client)
        {
            Reservation reservation = new Reservation(clientName, phoneNumber, noSeats, trip, responsibleEmployee, client);
            Optional<Reservation> result=reservationRepository.save(reservation);
            if (!result.HasValue)
                throw new Exception("Reservation did not saved");
            
            this.NotifyAllClients();

            //ReservationDTO r = DTOUtils.GetDTO(result.Value);
            return Optional<ReservationDTO>.Empty();

        }
        private void NotifyAllClients()
        {
            Console.WriteLine("Notifying all clients ...");
            foreach (var client in loggedClients.Values)
            {
                // client.ReservationUpdate();
                Task.Run(() => client.reservationUpdate());
            }
        }

        public void logout(Employee employee, IObserver client)
        {
            bool logoutClient = loggedClients.Remove(employee.Username);

            if (logoutClient == false)
                throw new Exception("User " + employee.Id + " is not logged in.");

        }

        public void addObserver(Employee employee, IObserver observer)
        {
           // loggedClients[employee] = observer;

        }

        public void removeObserver(IObserver observer)
        {
            throw new NotImplementedException();
        }
 
    }
}
