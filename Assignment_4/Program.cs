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
    class Program
    {
        static void Main(string[] args)
        {
            AirlineCompany airlineCompany = new AirlineCompany("Widowmakers");

            Flight flight1 = new Flight(1, "Helsinki", "Riga", DateTime.Now.AddHours(7), 237);
            Flight flight2 = new Flight(2, "Vaasa", "Stockholm", DateTime.Now.AddDays(2), 274);
            Flight flight3 = new Flight(3, "New York", "Sydney", DateTime.Now.AddMonths(1), 742);
            Flight flight4 = new Flight(4, "Amsterdam", "Istanbul", DateTime.Now.AddYears(1), 473);
            Flight flight5 = new Flight(5, "Tokyo", "London", DateTime.Now.AddDays(64), 728);

            airlineCompany[0] = flight1;
            airlineCompany[1] = flight2;
            airlineCompany[2] = flight3;
            airlineCompany[3] = flight4;
            airlineCompany[4] = flight5;

            while (true)
            {

                Console.WriteLine("1. Search flight by id value");
                Console.WriteLine("2. Show the cheapest flight");
                Console.WriteLine("3. Show the most expensive flight");
                Console.WriteLine("4. Show all flights");
                Console.WriteLine("5. Terminate program");

                Console.WriteLine("\nChoose an option: \n");
                string userInput = Console.ReadLine();

                if (int.TryParse(userInput, out int choice))
                {
                    switch (choice)
                    {
                        case 1:
                            Console.Write("\nEnter the flight you want to search for: \n\n");
                            if (int.TryParse(Console.ReadLine(), out int targetId))
                            {
                                Flight foundFlight = Flight.FindFlight(airlineCompany.GetFlights(), targetId);    

                                if (foundFlight != null)
                                {
                                    Console.WriteLine($"\nFlight {foundFlight.Id} is:\n\nOrigin: {foundFlight.Origin}\nDestination: {foundFlight.Destination}\nDate: {foundFlight.Date}\nPrice: {foundFlight.Price}\n");
                                }
                                else
                                {
                                    Console.WriteLine($"Flight {targetId} was not found.");
                                }
                            }
                            else
                            {
                                Console.WriteLine("That's not a valid input. Please enter a number between 1 - 5");
                            }
                            break;

                        case 2:
                            Flight cheapestFlight = airlineCompany.GetCheapestFlight();
                            if (cheapestFlight != null)
                            {
                                Console.WriteLine($"\nCheapest Flight is:\n\nFlight Id: {cheapestFlight.Id}\nOrigin: {cheapestFlight.Origin}\nDestination: {cheapestFlight.Destination}\nDate: {cheapestFlight.Date}\nPrice: {cheapestFlight.Price}\n");
                            }
                            else
                            {
                                Console.Write("No flight was found please contact customer support");
                            }
                            break;

                        case 3:
                            Flight expensiveFlight = airlineCompany.GetMostExpensiveFlight();
                            if (expensiveFlight != null)
                            {
                                Console.WriteLine($"\nMost Expensive Flight is:\n\nFlight Id: {expensiveFlight.Id}\nOrigin: {expensiveFlight.Origin}\nDestination: {expensiveFlight.Destination}\nDate: {expensiveFlight.Date}\nPrice: {expensiveFlight.Price}\n");
                            }
                            else
                            {
                                Console.WriteLine("No flight was found please contact customer support");
                            }
                            break;
                        
                        case 4:
                            Console.WriteLine("\nList of all flights after they have been sorted in ascending order is:\n");
                            foreach (var flight in airlineCompany.GetFlights())
                            {
                                Console.WriteLine($"Flight Id: {flight.Id}\nOrigin: {flight.Origin}\nDestination: {flight.Destination}\nDate: {flight.Date}\nPrice: {flight.Price}\n");
                            }
                            break;


                        case 5:
                            return;

                        default:
                            Console.WriteLine("\nPlease choose an option listed above (numbers 1 - 5)\n");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Not a valid option choose again");
                }

            }

        }
    }
}
