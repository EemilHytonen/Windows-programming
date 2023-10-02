/*
Write an application in C# in which you define class Concert to manage concert information. 
Relevant attributes for class Concert are title, location, date, time and price. Define the 
default constructor as well as some other meaningful constructors and a method, which returns 
concert information as text. Define also the following operators for the class:
== and Equals operators so that two Concert objects can be compared to each other 
< operator so that a Concert object is smaller than the other one if it's price is smaller 
> operator so that a Concert object is greater than the other one if it's price is greater 
 ++ and -- operators so that they would increase or decrease the concert price by 5 units  
In the main method of the application, define an ArrayList and initialize it by five Concert objects. 
Use operators to put the Concert objects in ascending order based on their price values and print out 
their information to the standard output device. Use defined operators to make sure they work correctly. 

e2101439 Eemil Hytönen
*/

namespace Assignment_3;

using System;
using System.Collections;
using System.Collections.Generic;

class Concert : IComparable<Concert>
{
    string Title;
    string Location;
    DateTime Date;
    string Time;
    double Price;

    public Concert(string Title, string Location, DateTime Date, string Time, double Price)
    { 
        this.Title = Title;
        this.Location = Location;
        this.Date = Date;
        this.Time = Time;
        this.Price = Price;
    }

    public double getPrice()
    {
        return this.Price;
    }
    public override string ToString()
    {
        return $"{Title},{Location},{Date},{Time},{Price}";
    }

    // This checks OBJECT Concert(s) against all other object concert(s)
    // == and Equals operators so that two Concert objects can be compared to each other 
    public static bool operator == (Concert c1, Concert c2)
    {
        if (c1.Equals(c2))
        return true;
        return false;
    }

    public static bool operator != (Concert c1, Concert c2)
    { 
        return !c1.Equals(c2);
        return true;
        return false;
    }

    // < operator so that a Concert object is smaller than the other one if it's price is smaller 

    public static bool operator < (Concert c1, Concert c2)
    { 
        if (c1.Price < c2.Price)
        return true;
        return false;
    }

    // > operator so that a Concert object is greater than the other one if it's price is greater 
    public static bool operator > (Concert c1, Concert c2)
    {
        if (c1.Price > c2.Price)
        return true;
        return false;
    }

     // ++ and -- operators so that they would increase or decrease the concert price by 5 units
    
    public static Concert operator ++ (Concert c)
    {
        c.Price += 5;
        return c;
    }

    public static Concert operator -- (Concert c)
    {
        c.Price -= 5;
        if (c.Price < 0)
        {
            c.Price = 0;
        }

        return c;
    }

    public int CompareTo(Concert other)
    {
        return Price.CompareTo(other.Price);
    }

    public override bool Equals(object? obj)
    {
        return obj is Concert concert &&
               Title == concert.Title &&
               Location == concert.Location &&
               Date == concert.Date &&
               Time == concert.Time &&
               Price == concert.Price;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Title, Location, Date, Time, Price);
    }
}

// Another way to sort the arraylist is to change it's type
class ConcertPriceComparer : IComparer
{
    public int Compare(object x, object y)
    {
        if (x is Concert && y is Concert)
        {
            var concertX = (Concert)x;
            var concertY = (Concert)y;
            return concertX.CompareTo(concertY); // Use class Concert's CompareTo method.
        }
        throw new ArgumentException("Objects are not of type Concert");
    }
}

class Program
{
    static void Main()
    {
        ArrayList concerts = new ArrayList();

        Concert concert1 = new Concert("Woodstock", "USA", DateTime.Parse("2008-8-27 23:00"), "23:00", 80.00);
        Concert concert2 = new Concert("Tomorrowland", "Austria", DateTime.Parse("2018-2-12 23:00"), "23:00", 180.00);
        Concert concert3 = new Concert("Ruisrock", "Finland", DateTime.Parse("2014-4-23 20:00"), "20:00", 40.00);
        Concert concert4 = new Concert("Himos Juhannus", "Finland", DateTime.Parse("2022-5-18 18:00"), "18:00", 90.00);
        Concert concert5 = new Concert("Opera", "Estonia", DateTime.Parse("2023-3-1 21:00"), "21:00", 60.00);

        concerts.Add(concert1);
        concerts.Add(concert2);
        concerts.Add(concert3);
        concerts.Add(concert4);
        concerts.Add(concert5);


        Console.WriteLine("Concerts before sorting:\n"); // Copy paste just to get the list out 
        Console.WriteLine(concert1);
        Console.WriteLine(concert2);
        Console.WriteLine(concert3);
        Console.WriteLine(concert4);
        Console.WriteLine(concert5);

        Console.WriteLine("\nConcerts after sorting:\n");

        concerts.Sort(new ConcertPriceComparer()); // Use the custom comparer.

        foreach (Concert concert in concerts)
        {
            Console.WriteLine(concert.ToString());
        }

        Console.WriteLine("\nConcert 1 == Concert 2: " + (concert1 == concert2));

        Console.WriteLine("\nConcert 1 < Concert 2: " + (concert1 < concert2));

        Console.WriteLine("\nConcsert 1 > Concert 2: " + (concert1 > concert2));

        Console.WriteLine($"\nConsert 1 original price is {concert1.getPrice()}");
        concert1++;
        Console.WriteLine($"\nConsert 1 increased price is {concert1.getPrice()}");
        concert1--; // Return to original price
        concert1--;
        Console.WriteLine($"\nConsert 1 decreased price is {concert1.getPrice()}");


    }
}