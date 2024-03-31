using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2MPP.Model
{
    internal class Trip : Entity<long>
    {
        private string Place { get; set; }
        private string TransportCompanyName{ get; set; }
        private DateTime Departure { get; set; }
        private float Price { get; set; }
        private int TotalSeats { get; set; }

        public Trip(string place, string transportCompanyName, DateTime departure, float price, int totalSeats)
        {
            this.Place = place;
            this.TransportCompanyName = transportCompanyName;
            this.Departure = departure;
            this.Price = price;
            this.TotalSeats = totalSeats;
        }

        public override bool Equals(object obj)
        {
            return obj is Trip trip &&
                   Place == trip.Place &&
                   TransportCompanyName == trip.TransportCompanyName &&
                   Departure == trip.Departure &&
                   Price == trip.Price &&
                   TotalSeats == trip.TotalSeats;
        }

        public override string ToString()
        {
            return "Trip{" +
                "place='" + Place + '\'' +
                ", transportCompanyName='" + TransportCompanyName + '\'' +
                ", departure=" + Departure +
                ", price=" + Price +
                ", totalSeats=" + TotalSeats +
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
