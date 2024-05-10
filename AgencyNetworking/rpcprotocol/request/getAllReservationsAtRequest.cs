
namespace AgencyNetworking.rpcprotocol
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