using MPPcSharp.repository;
using MPPcSharp.service;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Forms;
using TemaMPPcSharp.Repository;

namespace MPPcSharp
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form2(getService()));
        }

        static Service getService()
        {
            IDictionary<string, string> serverProps = new SortedList<string, string>();
            serverProps.Add("ConnectionString", GetConnectionStringByName("agentieTurism"));
            Console.WriteLine(serverProps.Values);
            TripDBRepository tripRepository = new TripDBRepository(serverProps);
            ReservationDBRepository reservationRepository = new ReservationDBRepository(serverProps);
            EmployeeDBRepository employeeRepository = new EmployeeDBRepository(serverProps);
            ClientDBRepository clientRepository = new ClientDBRepository(serverProps);
            return new Service(tripRepository, reservationRepository, employeeRepository, clientRepository);
     }

        static string GetConnectionStringByName(string name)
        {
            // Assume failure.
            string returnValue = null;

            // Look for the name in the connectionStrings section.
            ConnectionStringSettings settings = ConfigurationManager.ConnectionStrings[name];

            // If found, return the connection string.
            if (settings != null)
                returnValue = settings.ConnectionString;

            return returnValue;
        }
    }
}
