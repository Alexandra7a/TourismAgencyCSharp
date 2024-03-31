﻿using Lab2MPP.Model;
using Lab2MPP.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;
using Microsoft.Data.Sqlite;
using System.Data;
using System.Drawing;
using log4net.DateFormatter;

namespace TemaMPPcSharp.Repository
{
    internal class TripDBRepository : IRepository<long, Trip>
    {

        private static readonly ILog logger = LogManager.GetLogger("TripDBRepository");
        private IDbConnection connection;
        private string pattern = "yyyy-MM-dd HH:mm";

        IDictionary<String, string> props;
        public TripDBRepository(IDictionary<string, string> props)
        {
            logger.InfoFormat("Creating TripDBRepository {0} {1}" ,props.Keys.ToString(),props.Values.ToString());
            
            this.props = props;
            connection = DBConnection.getConnection(props);
        }

        public bool delete(long id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Trip> findAll()
        {
            logger.Info("entered the findAll method ");
            IList<Trip> trips = new List<Trip>();
            using (var comm = connection.CreateCommand())
            {
                comm.CommandText = "select id_trip, place, transportCompanyName, departure, price, totalSeats from [trips];";

                using (var dataR = comm.ExecuteReader())
                {
                    while (dataR.Read())
                    {

                        Int64 id = dataR.GetInt64(0);
                        string place = dataR.GetString(1);
                        string transportCompanyName = dataR.GetString(2);
                        DateTime departure = DateTime.Parse(dataR.GetString(3));
                        float price = dataR.GetFloat(4);
                        int totalSeats = dataR.GetInt32(5);

                        Trip trip = new Trip(place,transportCompanyName,departure,price,totalSeats);
                        trip.Id = id;
                        trips.Add(trip);
                    
                    }
                }
            }

            logger.InfoFormat("got all trips {0}",trips.ToArray() );
            return trips;
        }
        public IEnumerable<Trip> findAllTripPlaceTime(String placeToVisit, DateTime startTime, DateTime endTime)
        {
            logger.Info("entered the findAllTripPlaceTime method ");
            IList<Trip> filtered_trips = new List<Trip>();
            using (var comm = connection.CreateCommand())
            {
                comm.CommandText = "select id_trip, place, transportCompanyName, " +
                    "departure, price, totalSeats from [trips] where place=@placeToVisit;";

                IDbDataParameter paramPlace = comm.CreateParameter();
                paramPlace.ParameterName = "@placeToVisit ";
                paramPlace.Value = placeToVisit;
                comm.Parameters.Add(paramPlace);

               /* IDbDataParameter paramStartTime=comm.CreateParameter();
                paramStartTime.ParameterName = "@startTime";
                paramStartTime.Value = startTime.ToString(pattern);
                


                IDbDataParameter paramEndDate =comm.CreateParameter();
                paramEndDate.ParameterName = "@endTime";
                paramEndDate.Value = endTime.ToString(pattern);*/

                using (var dataR = comm.ExecuteReader()) { 
               
                    while(dataR.Read())
                    {
                        
                        Int64 id = dataR.GetInt64(0);
                        string place = dataR.GetString(1);
                        string transportCompanyName = dataR.GetString(2);
                        DateTime departure =DateTime.Parse(dataR.GetString(3));
                        float price = dataR.GetFloat(4);
                        int totalSeats = dataR.GetInt32(5);

                        Trip trip = new Trip(place, transportCompanyName, departure, price, totalSeats);
                        trip.Id = id;
                        if (departure>startTime && departure<endTime)
                            filtered_trips.Add(trip);
                    }
                }
            }
            logger.InfoFormat("The filtered list {0}", filtered_trips);
            return filtered_trips;
        }

        public Trip findOne(long id)
        {
            throw new NotImplementedException();
        }  
       

        public bool save(Trip entity)
        {
            throw new NotImplementedException();
        }

        public bool update(long id, Trip entity)
        {
            throw new NotImplementedException();
        }
    }
}
