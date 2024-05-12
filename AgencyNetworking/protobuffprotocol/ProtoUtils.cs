using AgencyModel.model;
using AgencyModel.model.dto;
using Proto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using TripDTO = AgencyModel.model.dto.TripDTO;
using ClientDTO = AgencyModel.model.dto.ClientDTO;
using EmployeeDTO = AgencyModel.model.dto.EmployeeDTO;
using TripFilterBy = AgencyModel.model.dto.TripFilterBy;
using ReservationDTO = AgencyModel.model.dto.ReservationDTO;


namespace AgencyNetworking.protobuffprotocol
{
    internal class ProtoUtils
    {
        public static Proto.Response createUpdateResponse()
        {
            Proto.Response response = new Proto.Response { Type=Proto.Response.Types.ReponseType.Update};
            return response;
        }

        public static Proto.Response createEmptyOkResponse()
        {
            Proto.Response response = new Proto.Response { Type = Proto.Response.Types.ReponseType.Ok };
            return response;
        }
        
        public static Proto.Response createErrorResponse(string text)
        {
            Proto.Response response = new Proto.Response { Type = Proto.Response.Types.ReponseType.Error };
            response.Error = text;
            return response;

        }

        public static Proto.Response createFindAllTripsResponse(List<TripDTO> trips)
        {
            //make a reponse which contains trip data to transfer
            Proto.Response response = new Proto.Response { Type = Proto.Response.Types.ReponseType.Ok };
            foreach(TripDTO trip in trips)
            {
                Proto.TripDTO tripDTO = new Proto.TripDTO
                {
                    Id = trip.Id,
                    Place = trip.Place,
                    TransportCompanyName = trip.TransportCompanyName,
                    Departure = trip.Departure.ToString(),
                    Price = trip.Price,
                    TotalSeats = trip.TotalSeats

                };
                response.Trips.Add(tripDTO);

            }
            return response;
        } 

        public static Proto.Response createFindAllClientsResponse(List<ClientDTO> clients)
        {
            Proto.Response response = new Proto.Response { Type = Proto.Response.Types.ReponseType.Ok };
            foreach (ClientDTO client in clients)
            {
                Proto.ClientDTO dto = new Proto.ClientDTO
                {
                    Id = client.Id,
                    Name=client.Name,
                    BirthDate=client.BirthDate.ToString()

                };
                response.Clients.Add(dto);

            }
            return response;
        }


        public static Proto.Response createNumberReservationsResponse(int number)
        {
            Proto.Response response = new Proto.Response { Type = Proto.Response.Types.ReponseType.Ok };
            response.No=number;
            return response;
        }

        public static EmployeeDTO getEmployeeDTO(Proto.Request request)
        {
            var employeeDTO = request.UserDto;
            return new EmployeeDTO(employeeDTO.Username, employeeDTO.Password);
        }

        public static TripFilterBy getTripFilterByDataFromRequest(Proto.Request request)
        {
            var data = request.TripFilterByDataRequest;
            return new TripFilterBy(data.PlaceToVisit, DateTime.Parse(data.StartTime), DateTime.Parse(data.EndTime));
        }
        public static ReservationDTO getReservationFromRequest(Proto.Request request)
        {
            /*
             * Must transform reservation proto in normal reservation */
            var reservationDTO = request.ReservationDto;

            AgencyModel.model.Employee employee = new AgencyModel.model.Employee(reservationDTO.ResponsibleEmployee.Username,
                    reservationDTO.ResponsibleEmployee.Password);

            AgencyModel.model.Trip trip = new AgencyModel.model.Trip(reservationDTO.Trip.Place,
                    reservationDTO.Trip.TransportCompanyName,
                    DateTime.Parse(reservationDTO.Trip.Departure),
                    reservationDTO.Trip.Price,
                    reservationDTO.Trip.TotalSeats
                    );
            
            AgencyModel.model.Client client = new AgencyModel.model.Client(reservationDTO.Client.Name, DateTime.Parse(reservationDTO.Trip.Departure));

            return new ReservationDTO(reservationDTO.ClientName,
                    reservationDTO.PhoneNumber,
                    reservationDTO.NoSeats,
                    trip,
                    employee,
                    client);

        }

    }
}
