using Lab2MPP.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemaMPPcSharp.Model
{
    internal class Client : Entity<long>
    {
        private string Usernamr { get; set; }
        private DateTime BirthDate  { get; set; } // i cannot use just a date component. I have read about DateOnly but idk

        public Client(string usernamr, DateTime birthDate)
        {
            Usernamr = usernamr;
            BirthDate = birthDate;
        }
    }
}
