using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Common.model
{
    public class Employee : Entity<long>
    {
        private string username { get; set; }
        private string password { get; set; }
        public string Username
        {
            get { return username; }
            set { username = value; }
        }
        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        public Employee(string username, string password)
        {
            this.username = username;
            this.password = password;
        }
    }
}
