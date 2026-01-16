using System.Data.Common;

namespace SafeBoda.Core
{
    public class Location
    {

        public Guid Id { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }

        public Location() { }

        public Location(double latitude, double longitude)
        {
            Latitude = latitude;
            Longitude = longitude;
        }
    }

    public class Rider
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }

        public Rider(Guid id, string name, string phoneNumber)
        {
            Id = id;
            Name = name;
            PhoneNumber = phoneNumber;
        }
    }

    public class Driver
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string MotoPlateNumber { get; set; }

        public Driver(Guid id, string name, string phoneNumber, string motoPlateNumber)
        {
            Id = id;
            Name = name;
            PhoneNumber = phoneNumber;
            MotoPlateNumber = motoPlateNumber;
        }
    }

    public class Trip
    {
        public Guid Id { get; set; }
        public Guid RiderId { get; set; }
        public Guid DriverId { get; set; }

        public Location Start { get; set; }
        public Location End { get; set; }

        public decimal Fare { get; set; }
        public DateTime RequestTime { get; set; }
        
        public Trip() { } 
        
        public Trip(Guid id, Guid riderId, Guid driverId, Location start, Location end, decimal fare, DateTime requestTime)
        {
            Id = id;
            RiderId = riderId;
            DriverId = driverId;
            Start = start;
            End = end;
            Fare = fare;
            RequestTime = requestTime;
        }
    }

    
}
