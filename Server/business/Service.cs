﻿using Common.business;
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
        private readonly IDictionary<Employee, IObserver> loggedClients;

        public Service(TripDBRepository repo, ReservationDBRepository repo2, EmployeeDBRepository repo3, ClientDBRepository repo4)
        {
            this.tripRepository = repo;
            this.reservationRepository = repo2;
            this.employeeRepository = repo3;
            this.clientRepository = repo4;

            loggedClients=new Dictionary<Employee, IObserver>();
        }

        public IEnumerable<Trip> getAllTrip()
        {
            return tripRepository.findAll();
        }

        /*THE LOG IN**/
        public Employee findUser(String user, String pass)
        {
            Employee result = employeeRepository.findOnebyUsername(user);
            if (result != null && result.Password.Equals(pass))
            {
                if (loggedClients.ContainsKey(result)) {
                    throw new Exception("User already logged!");
                }
               
                    return result;
            }
            return null;

        }

        public int getAllReservationsAt(long id)
        {
            return reservationRepository.getAllReservationsAt(id);
        }

        public IEnumerable<Common.model.Client> getAllClients()
        {
            return (IEnumerable<Common.model.Client>)clientRepository.findAll();
        }

        public IEnumerable<Trip> getAllFilteredTris(string place, DateTime startDate, DateTime endDate)
        {
            return tripRepository.findAllTripPlaceTime(place, startDate, endDate);
        }

        public bool saveReservation(string clientName, string phoneNumber, int noSeats, Trip trip, Employee responsibleEmployee, Common.model.Client client)
        {
            Reservation reservation = new Reservation(clientName, phoneNumber, noSeats, trip, responsibleEmployee, client);
            if (!reservationRepository.save(reservation))
                throw new Exception("Not saved");


            foreach (var observer in loggedClients.Values)
            {
                observer.notify();
            }
            return true;

        }

        public void logOutClicked()
        {
            throw new NotImplementedException();
        }

        public void addObserver(Employee employee, IObserver observer)
        {
            loggedClients[employee] = observer;

        }

        public void removeObserver(IObserver observer)
        {
            throw new NotImplementedException();
        }

         }
}
