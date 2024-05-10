using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgencyModel.model.dto
{
    [Serializable]

    public class ClientDTO
    {
        private long _id;
        private string name;
        private DateTime birthDate;
        public long Id { get { return _id; } set { _id = value; } }

        public string Name { get { return name; } set { name = value; } }
        public DateTime BirthDate { get { return birthDate; } set { birthDate = value; } }

        public ClientDTO(string name, DateTime birthDate)
        {
            this.name = name;
            this.birthDate = birthDate;
        }
    }
}
