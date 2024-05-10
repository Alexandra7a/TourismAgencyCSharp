using  Common.model;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Server.repository
{
    public interface IRepository<ID, E> where E : Entity<ID>
    {
        E findOne(ID id);
        bool update(ID id, E entity);
        bool delete(ID id);
        bool save(E  entity);
        IEnumerable<E> findAll();
    }
}
