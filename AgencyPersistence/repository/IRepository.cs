using AgencyModel.model;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Utils;

namespace AgencyPersistence.repository
{
    public interface IRepository<ID, E> where E : Entity<ID>
    {
        Optional<E> findOne(ID id);
        Optional<E> update(ID id, E entity);
        Optional<E> delete(ID id);
        Optional<E> save(E  entity);
        IEnumerable<E> findAll();
    }
}
