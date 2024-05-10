using log4net;
using log4net.Repository.Hierarchy;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AgencyModel.model;
using Utils;
using AgencyPersistence.repository.interfaces;

namespace AgencyPersistence.repository
{
    public class EmployeeDBRepository : IEmployeeRepository
    {
        private static readonly ILog logger = LogManager.GetLogger("EmployeeDBRepository");

        private IDbConnection connection;

        IDictionary<String, string> props;
        public EmployeeDBRepository(IDictionary<string, string> props)
        {
            logger.InfoFormat("Creating EmployeeDBRepository {0} " , props);
            this.props = props;
            connection = DBConnection.getConnection(props);
        }



        public Optional<Employee> delete(long id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Employee> findAll()
        {
            throw new NotImplementedException();
        }

        public Optional<Employee> findOne(long id)
        {
            throw new NotImplementedException();
        }

        public Optional<Employee> findOnebyUsername(string username)
        {
            logger.Info("entered the findOnebyUsername method ");
            Console.WriteLine("Entered repo employee");
            using (var comm = connection.CreateCommand())
            {
                comm.CommandText = "select username, pass from employees where username=@username";

                IDbDataParameter paramUser = comm.CreateParameter();
                paramUser.ParameterName = "@username";
                paramUser.Value = username;
                comm.Parameters.Add(paramUser);

                using (var dataR = comm.ExecuteReader())
                {
                    if (dataR.Read())
                    {
                        string user = dataR.GetString(0);
                        string pass = dataR.GetString(1);
                        Employee employee = new Employee(user, pass);
                        logger.InfoFormat("usern found {0}", employee.ToString());
                        return Optional<Employee>.Of(employee);
                    }
                }
            }

            logger.InfoFormat("user not found {0}");
            return Optional<Employee>.Empty();

        }


        public Optional<Employee> save(Employee entity)
        {
            throw new NotImplementedException();
        }

        public Optional<Employee> update(long id, Employee entity)
        {
            throw new NotImplementedException();
        }
    }
}
