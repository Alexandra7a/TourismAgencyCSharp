using Lab2MPP.Model;
using Lab2MPP.Repository;
using log4net;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace TemaMPPcSharp.Repository
{
    internal class ReservationDBRepository : IRepository<long, Reservation>
    {

        private static readonly ILog logger = LogManager.GetLogger("ReservationDBRepository");
        private IDbConnection connection;

        IDictionary<String, string> props;
        public ReservationDBRepository(IDictionary<string, string> props)
        {
            logger.InfoFormat("Creating ReservationDBRepository {0} ", props);
            this.props = props;
            connection = DBConnection.getConnection(props);
        }

        public bool delete(long id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Reservation> findAll()
        {
            throw new NotImplementedException();
        }

        public  Reservation  findOne(long id)
        {
            throw new NotImplementedException();
        }

        public bool save(Reservation entity)
        {

            logger.InfoFormat("Entered save reservation {0}" + entity);
            using (var comm=connection.CreateCommand())
            {
                comm.CommandText = "insert into reservations (clientName, phoneNumber, noSeats, id_trip, username_employee, id_client) " +
                    "VALUES (@clientName, @phoneNumber, @noSeats, @id_trip, @username_employee, @id_client)";

                IDbDataParameter clientN = comm.CreateParameter();
                clientN.ParameterName = "@clientName";
                clientN.Value = entity.ClientName;
                comm.Parameters.Add(clientN);

                IDbDataParameter phoneNumber = comm.CreateParameter();
                phoneNumber.ParameterName = "@phoneNumber";
                phoneNumber.Value = entity.PhoneNumber;
                comm.Parameters.Add(phoneNumber);

                IDbDataParameter noSeats = comm.CreateParameter();
                noSeats.ParameterName = "@noSeats";
                noSeats.Value = entity.NoSeats;
                comm.Parameters.Add(noSeats);        
                
                IDbDataParameter id_trip = comm.CreateParameter();
                id_trip.ParameterName = "@id_trip";
                id_trip.Value = entity.Trip;
                comm.Parameters.Add(id_trip);

                IDbDataParameter username_employee = comm.CreateParameter();
                username_employee.ParameterName = "@username_employee";
                username_employee.Value = entity.Employee;
                comm.Parameters.Add(username_employee);

      

                IDbDataParameter id_client = comm.CreateParameter();
                id_client.ParameterName = "@id_client";
                id_client.Value = entity.Client;
                comm.Parameters.Add(id_client);

                var result = comm.ExecuteNonQuery();
                if (result == 0)
                {
                    logger.Error("Something went wrong when adding the reservation {0}" + entity);
                    return false;
                }    

            }

            return true;
        }

        public bool update(long id, Reservation entity)
        {
            throw new NotImplementedException();
        }
    }
}
