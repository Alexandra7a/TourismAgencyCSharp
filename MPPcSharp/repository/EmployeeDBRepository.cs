using Lab2MPP.Model;
using Lab2MPP.Repository;
using log4net;
using log4net.Repository.Hierarchy;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPPcSharp.repository
{
    internal class EmployeeDBRepository : IRepository<long, Employee>
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



        public bool delete(long id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Employee> findAll()
        {
            throw new NotImplementedException();
        }

        public Employee findOne(long id)
        {
            throw new NotImplementedException();
        }

        public Employee findOnebyUsername(string username)
        {
            logger.Info("entered the findOnebyUsername method ");
           
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
                        return employee;
                    }
                }
            }

            logger.InfoFormat("user not found {0}");
            return null;
           
        }


        public bool save(Employee entity)
        {
            throw new NotImplementedException();
        }

        public bool update(long id, Employee entity)
        {
            throw new NotImplementedException();
        }
    }
}
