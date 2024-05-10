using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.model;
namespace Common.business
{
    public interface IObserver
    {
        public void reservationMade();
    }
}
