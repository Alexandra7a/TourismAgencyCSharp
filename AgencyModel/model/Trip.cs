using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgencyModel.model
{
    [Serializable]

    public class Trip : Entity<long>
    {
        private string place { get; set; }
        private string transportCompanyName{ get; set; }
        private DateTime departure { get; set; }
        private float price { get; set; }
        private int totalSeats { get; set; }

        public string TransportCompanyName { get { return transportCompanyName; } set { transportCompanyName = value; } }
        public string Place{  get { return place; } set { place = value; } }
        public DateTime Departure { get { return departure; } set { departure = value; } }
        public float Price { get { return price; } set { price = value; } }
        public int TotalSeats { get { return totalSeats; } set { totalSeats = value; } }

        public Trip(string place, string transportCompanyName, DateTime departure, float price, int totalSeats)
        {
            this.place = place;
            this.transportCompanyName = transportCompanyName;
            this.departure = departure;
            this.price = price;
            this.totalSeats = totalSeats;
        }

        public override bool Equals(object obj)
        {
            return obj is Trip trip &&
                   place == trip.Place &&
                   transportCompanyName == trip.TransportCompanyName &&
                   departure == trip.Departure &&
                   price == trip.Price &&
                   totalSeats == trip.TotalSeats;
        }

        public override string ToString()
        {
            return "Trip{" +
                "place='" + place + '\'' +
                ", transportCompanyName='" + transportCompanyName + '\'' +
                ", departure=" + departure +
                ", price=" + price +
                ", totalSeats=" + totalSeats +
                '}';
        }

        public override int GetHashCode()
        {
            int hashCode = 986826059;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Place);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(TransportCompanyName);
            hashCode = hashCode * -1521134295 + Departure.GetHashCode();
            hashCode = hashCode * -1521134295 + Price.GetHashCode();
            hashCode = hashCode * -1521134295 + TotalSeats.GetHashCode();
            return hashCode;
        }
    }
}
