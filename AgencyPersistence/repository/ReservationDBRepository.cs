using AgencyModel.model;
using AgencyPersistence.repository.interfaces;
using log4net;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils;
//using System.Web.UI.WebControls;

namespace AgencyPersistence.repository
{
    public class ReservationDBRepository : IReservationRepository
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

        public Optional<Reservation> delete(long id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Reservation> findAll()
        {
            throw new NotImplementedException();
        }

        public Optional<Reservation> findOne(long id)
        {
            throw new NotImplementedException();
        }

        public Optional<Reservation> save(Reservation entity)
        {

            logger.InfoFormat("Entered save reservation {0}", entity);
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
                id_trip.Value = entity.Trip.Id;
                comm.Parameters.Add(id_trip);

                IDbDataParameter username_employee = comm.CreateParameter();
                username_employee.ParameterName = "@username_employee";
                username_employee.Value = entity.responsibleEmployee.Username;
                comm.Parameters.Add(username_employee);

      

                IDbDataParameter id_client = comm.CreateParameter();
                id_client.ParameterName = "@id_client";
                id_client.Value = entity.Client.Id;
                comm.Parameters.Add(id_client);

                var result = comm.ExecuteNonQuery();
                if (result == 0)
                {
                   
                    logger.Error("Something went wrong when adding the reservation {0}" + entity);
                    return Optional<Reservation>.Empty();
                }    

            }

            return Optional<Reservation>.Of(entity);
        }

        public Optional<Reservation> update(long id, Reservation entity)
        {
            throw new NotImplementedException();
        }

        public int getAllReservationsAt(long id)
        {
            logger.InfoFormat("Entered getAllReservationsAt {0}", id);
            using (var comm = connection.CreateCommand())
            {
                comm.CommandText = "select sum(noSeats) from reservations group by id_trip having id_trip=@id_trip;";
                IDbDataParameter id_trip = comm.CreateParameter();
                id_trip.ParameterName = "@id_trip";
                id_trip.Value =id;
                comm.Parameters.Add(id_trip);
                using (var dataR = comm.ExecuteReader())
                { 
                    if(dataR.Read())
                    {
                        Console.WriteLine("Aici sunt ", dataR.GetInt32(0));
                        int result = dataR.GetInt32(0);
                        Console.WriteLine("RESERVATION NUMBER IS {0}", result);
                        return result;
                    }
                }
            }
            Console.WriteLine("RESERVATION NUMBER IS ", 0);

            return 0;
        }
    }
}
