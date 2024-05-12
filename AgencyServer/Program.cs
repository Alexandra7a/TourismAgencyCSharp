using AgencyModel.model;
 using System.Configuration;
using AgencyPersistence.repository;
using AgencyServices;
using AgencyServer.service;
using AgencyPersistence.repository.interfaces;
using AgencyNetworking.utils;

namespace AgencyServer
{
    internal class startServer
    {
        static void Main(string[] args)
        {

            IDictionary<string, string> serverProps = new SortedList<string, string>();
            serverProps.Add("ConnectionString", GetConnectionStringByName("agentieTurism"));
            Console.WriteLine(serverProps.Values);
            ITripRepository tripRepository = new TripDBRepository(serverProps);
            IReservationRepository reservationRepository = new ReservationDBRepository(serverProps);
            IEmployeeRepository employeeRepository = new EmployeeDBRepository(serverProps);
            IClientRepository clientRepository = new ClientDBRepository(serverProps);
            IService service = new Service(tripRepository, reservationRepository, employeeRepository, clientRepository);
            startPROTOserver(service);
        }

        static void startPROTOserver(IService service)
        {
        
            ConcurrentAbstractServer server = new ConcurrentServerProto("127.0.0.1", 55556, service);
            server.Start();
        }
        static void startRPCserver(IService service)
        {
            Server server = new Server("127.0.0.1", 55556, service);
            server.Start();
        }

        static string GetConnectionStringByName(string name)
        {
            // Assume failure.
            string returnValue = null;

            // Look for the name in the connectionStrings section.
            ConnectionStringSettings settings = ConfigurationManager.ConnectionStrings[name]; // EROARE LA CITIREA DIN FISIER


            // If found, return the connection string.
            if (settings != null)
                returnValue = settings.ConnectionString;

            return returnValue;
        }
    }
}
