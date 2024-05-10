using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgencyModel.model.dto
{

    public class DTOUtils
    {
        public static Employee GetFromDTO(EmployeeDTO emdto)
        {
            string id = emdto.Username;
            string pass = emdto.Password;
            return new Employee(id, pass);
        }

        public static EmployeeDTO GetDTO(Employee employee)
        {
            string id = employee.Username;
            string pass = employee.Password;
            return new EmployeeDTO(id, pass);
        }

        public static TripDTO GetDTO(Trip trip)
        {
            TripDTO tripDTO = new TripDTO(trip.Place, trip.TransportCompanyName, trip.Departure, trip.Price, trip.TotalSeats);
            tripDTO.Id = trip.Id;
            return tripDTO;
        }

        public static Trip GetFromDTO(TripDTO tripDTO)
        {
            Trip trip = new Trip(tripDTO.Place, tripDTO.TransportCompanyName, tripDTO.Departure, tripDTO.Price, tripDTO.TotalSeats);
            trip.Id = tripDTO.Id;
            return trip;
        }

        public static Client GetFromDTO(ClientDTO clientDTO)
        {
            Client client = new Client(clientDTO.Name, clientDTO.BirthDate);
            client.Id = clientDTO.Id;
            return client;
        }

        public static ClientDTO GetDTO(Client client)
        {
            ClientDTO clientDTO = new ClientDTO(client.Name, client.BirthDate);
            clientDTO.Id = client.Id;
            return clientDTO;
        }
    }

}
