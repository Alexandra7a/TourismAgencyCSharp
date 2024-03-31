using Lab2MPP.Repository;
using log4net;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TemaMPPcSharp.Model;

namespace MPPcSharp.repository
{
    internal class ClientDBRepository : IRepository<long, Client>
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


        public bool delete(long id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Client> findAll()
        {
            throw new NotImplementedException();
        }

        public Client findOne(long id)
        {
            throw new NotImplementedException();
        }

        public bool save(Client entity)
        {
            throw new NotImplementedException();
        }

        public bool update(long id, Client entity)
        {
            throw new NotImplementedException();
        }
    }
}
