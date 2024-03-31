using Lab2MPP.Model;
using Lab2MPP.Repository;
using MPPcSharp.repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TemaMPPcSharp.Repository;

namespace MPPcSharp.service
{
    internal class Service
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
            if (result !=null && result.Password.Equals(pass))
                return result;

            return null;
          
        }


    }
}
