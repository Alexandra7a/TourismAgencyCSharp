using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgencyModel.model
{
    [Serializable]

    public class Client : Entity<long>
    {
        private string _name;
        private DateTime _birthDate;

        public Client(string name, DateTime birthDate)
        {
            _name = name;
            _birthDate = birthDate;
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public DateTime BirthDate
        {
            get { return _birthDate; }
            set { _birthDate = value; }
        }

        public override string ToString()
        {
            return "id" + Id + "Client: " + _name;
        }
    }
}
