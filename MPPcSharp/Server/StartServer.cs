using Common.business;
using Server.business;
using Server.networking;
using Server.repository;
using System.Configuration;

namespace Server
{
    internal class startServer
    {
        static void Main(string[] args)
        {
            IDictionary<string, string> serverProps = new SortedList<string, string>();
            serverProps.Add("ConnectionString", GetConnectionStringByName("agentieTurism"));
            Console.WriteLine(serverProps.Values);
            TripDBRepository tripRepository = new TripDBRepository(serverProps);
            ReservationDBRepository reservationRepository = new ReservationDBRepository(serverProps);
            EmployeeDBRepository employeeRepository = new EmployeeDBRepository(serverProps);
            ClientDBRepository clientRepository = new ClientDBRepository(serverProps);
            IService service=new Service(tripRepository, reservationRepository, employeeRepository, clientRepository);

            Server.networking.Server server = new Server.networking.Server("127.0.0.1", 55556,service);
            server.Start();
        }

        static string GetConnectionStringByName(string name)
        {
            // Assume failure.
            string returnValue = null;

            // Look for the name in the connectionStrings section.
            ConnectionStringSettings settings = ConfigurationManager.ConnectionStrings["AgentieTurism"];

            // If found, return the connection string.
            if (settings != null)
                returnValue = settings.ConnectionString;

            return returnValue;
        }
    }
}
