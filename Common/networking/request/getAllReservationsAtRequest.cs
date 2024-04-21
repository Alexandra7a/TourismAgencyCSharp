using Common.networking.request;

namespace Common.networking.request
{
    [Serializable]
    public class getAllReservationsAtRequest : IRequest
    {
        public long id;

        public getAllReservationsAtRequest(long id)
        {
            this.id = id;
        }
    }
}