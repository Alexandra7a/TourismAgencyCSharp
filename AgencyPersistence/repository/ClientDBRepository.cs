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

namespace AgencyPersistence.repository
{
    public class ClientDBRepository :IClientRepository
    {

        private static readonly ILog logger = LogManager.GetLogger("ClientDBRepository");

        private IDbConnection connection;

        IDictionary<String, string> props;
        public ClientDBRepository(IDictionary<string, string> props)
        {
            logger.InfoFormat("Creating ClientDBRepository {0} ", props);
            this.props = props;
            connection = DBConnection.getConnection(props);
        }


        public Optional<Client> delete(long id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Client> findAll()
        {
            logger.Info("entered the findAll method ");
            IList<Client> clients = new List<Client>();
            using (var comm = connection.CreateCommand())
            {
                comm.CommandText = "select id_client,username,birthDay from [clients];";

                using (var dataR = comm.ExecuteReader())
                {
                    while (dataR.Read())
                    {
                        long id = dataR.GetInt64(0);
                        string username = dataR.GetString(1);
                        string birthday = dataR.GetString(2);
                        Client client = new Client(username, DateTime.Parse(birthday));
                        client.Id = id;
                        clients.Add(client);

                    }
                }
                logger.Info("finised findAll");
                return clients;
            }
        }

        public Optional<Client> findOne(long id)
        {
            throw new NotImplementedException();
        }

        public Optional<Client> save(Client entity)
        {
            throw new NotImplementedException();
        }

        public Optional<Client> update(long id, Client entity)
        {
            throw new NotImplementedException();
        }
    }
}
