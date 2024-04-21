using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.networking.response
{
    [Serializable]
    public class ErrorResponse : IResponse
    {
        public string message;

        public ErrorResponse(string message)
        {
            this.message = message;
        }
    }
}
