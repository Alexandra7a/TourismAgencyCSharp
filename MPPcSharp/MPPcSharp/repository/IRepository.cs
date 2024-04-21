using Lab2MPP.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2MPP.Repository
{
    internal interface IRepository<ID, E> where E : Entity<ID>
    {
        E findOne(ID id);
        bool update(ID id, E entity);
        bool delete(ID id);
        bool save(E  entity);
        IEnumerable<E> findAll();
    }
}
