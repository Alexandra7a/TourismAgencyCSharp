using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.model;

namespace Common.networking.response
{
    [Serializable]
    public class LoginResponse : IResponse
    {
        public Employee employee;

        public LoginResponse(Employee employee)
        {
            this.employee = employee;
        }
    }
}
