namespace Common.networking.response
{
    [Serializable]
    public class getAllReservationsAtResponse :IResponse
    {
        public int no;
        public getAllReservationsAtResponse(int no) { this.no = no; }
    }
}