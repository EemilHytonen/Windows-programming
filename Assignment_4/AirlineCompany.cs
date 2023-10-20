/*
Write an application which can be used to manage the flight information of an airline company. 

To do this define class AirlineCompany so that its attributes are a readonly field called airline 
name and a collection of type SortedList for holding flight information in ascending order based on flight price.
The key value in the sorted list should be flight object and the value, the flight price. 

For this purpose, define class Flight, whose attributes are id, origin, destination, date and price. 
For class Flight, define necessary constructors and properties and FindFlight() method 
which returns the flight information if the correct flight id is provided. 

Define indexer for class AirlineCompany so that it is possible to initialize the collection of flights 
and also get objects through indexing. In class AirlineCompany define also methods, 
which will return the information of the cheapest and the most expensive flight. 

Create objects of classes and make sure that FindFlight(), GetCheapestFligh() 
and GetMostExpensiveFlight() methods work correctly. 

e2101439
*/

using System;
using System.Collections.Generic;

namespace Assignment_4
{
    class AirlineCompany
    {
        readonly string airlineName;
        SortedList<Flight, double> flights;

        public AirlineCompany(string airlineName)
        {
            this.airlineName = airlineName;
            flights = new SortedList<Flight, double>(new FlightPriceComparer());  
        }

        public Flight this[int index]
        {
            get
            {
                return flights.Keys[index];
            }
            set
            {
                flights.Add(value, value.Price);
            }
        }

        public List<Flight> GetFlights()
        {
            return new List<Flight>(flights.Keys);
        }

        public Flight GetCheapestFlight()
        {
            if (flights.Count > 0)
            {
                return flights.Keys[0];
            }
            return null;
        }

        public Flight GetMostExpensiveFlight()
        {
            if (flights.Count > 0)
            {
                return flights.Keys[flights.Count - 1]; // .Count gets number of elements and then we just subtract 1 to get last index since the first index is 0, not 1
            }
            return null;
        }


    }
}
