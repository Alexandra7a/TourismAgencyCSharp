using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.model;

namespace Common.networking.response
{
      [Serializable]
  public class NotifyResponse : IResponse
    {
        public Reservation donation;

        public NotifyResponse(Reservation donation)
        {
            this.donation = donation;
        }
    }
}
