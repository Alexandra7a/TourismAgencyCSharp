using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2MPP.Model
{
    internal class Entity<ID>
    {
        protected ID id;
        public ID Id { get; set; }
    }
}