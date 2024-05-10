using System;

namespace TripNetworking
{
    [Serializable]
    public enum ResponseType
    {
        OK,
        ERROR,
        UPDATE,
        NEW_MESSAGE,
        FRIEND_LOGGED_IN,
        FRIEND_LOGGED_OUT
    }
}