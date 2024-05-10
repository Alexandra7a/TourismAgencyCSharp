using System;

namespace TripNetworking
{
    [Serializable]
    public enum RequestType
    {
        LOGIN,
        LOGOUT, 
        FIND_ALL_TRIPS,
        GET_RESERVATIONS,
        FIND_ALL_CLIENTS, 
        FILTER_TRIPS, 
        RESERVE_TICKET
    }
}