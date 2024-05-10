using Common.business;
using Common.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientForm
{
    [Serializable]
    internal class AgencyViewController:IObserver
    {

        private IService service;
        private Employee responsibleEmployee;
        
        public AgencyViewController()
        {
        }
        public void setService(IService service)
        {
            this.service = service;
            //this.service.addObserver(this);
        }

        public void notify()
        {
            throw new NotImplementedException();
        }

        internal List<Trip> getAllTrip()
        {
            return (List<Trip>)service.getAllTrip();

        }

        internal int getAllReservationsAt(long id)
        {
           return service.getAllReservationsAt(id);
        }

        internal List<Client> getAllClients()
        {
            return (List<Client>)service.getAllClients();
        }

        internal List<Trip> getAllFilteredTris(string place, DateTime startDate, DateTime endDate)
        {
        return (List<Trip>)service.getAllFilteredTris(place, startDate, endDate);
        }

        internal bool saveReservation(string clientName, string phoneNumber, int noSeats, Trip trip, Client client)
        {
            return service.saveReservation(clientName, phoneNumber, noSeats, trip,responsibleEmployee, client);
        }

        internal void findUser(string user, string pass)
        {
           // Employee employe = service.findUser(user, pass, this);
            //this.responsibleEmployee = employe;


        }

        public void reservationMade()
        {
            throw new NotImplementedException();
        }
    }
}
