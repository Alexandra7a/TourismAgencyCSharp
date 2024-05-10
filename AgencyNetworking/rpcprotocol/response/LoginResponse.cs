using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AgencyModel.model;

namespace AgencyNetworking.rpcprotocol
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
