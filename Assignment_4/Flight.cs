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
    class Flight
    {
        public int Id { get; }
        public string Origin { get; set; }
        public string Destination { get; set; }
        public DateTime Date { get; set; }
        public double Price { get; set; }

        public Flight(int id, string origin, string destination, DateTime date, double price)
        {
            this.Id = id;
            this.Origin = origin;
            this.Destination = destination;
            this.Date = date;
            this.Price = price;
        }

        public static Flight FindFlight(List<Flight> flights, int id)
        {
            foreach (var flight in flights)
            { 
                if (flight.Id == id)
                {
                    return flight;
                }
            }
            return null;
        }
    }
}