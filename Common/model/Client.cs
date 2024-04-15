﻿using Common.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.model
{
    [Serializable]

    public class Client : Entity<long>
    {
        private string username;
        private DateTime birthDay;

        public string Username { get { return username; } set { username = value; } }
        public DateTime BirthDay  { get { return birthDay; } set { birthDay = value; } }

        public Client(string usernamr, DateTime birthDate)
        {
            username = usernamr;
            birthDay = birthDate;
        }
    }
}
