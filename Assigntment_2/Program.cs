/*
 * 
Write an application in C# which reads the information of customers and their purchases from the standard input device
and allows searching purchase and customer information.When a purchase information is searched the application must print
the information of relevant customer too. When a customer information is searched, the application must print the 
information of customer's purchase too. A customer might have one or more purchases and one purchase can include one 
or many products. For each purchase there should be an array of product names and their amounts. Define separate classes 
for customer and purchase information. The attributes for the Customer class should be name, id and purchase ids (an array).
Define the constructor and a method which returns the customer's and his/her purchase information. The attributes for the 
Purchase class should be purchase id, date and time and an array of product names and their amounts, . Define the constructor 
and a method which returns the purchase information if the correct purchase id is passed to it. Hint: To make the application 
more professional define a class CustomerPurchaseHandler, which receives an array of customers and purchases and provides 
methods to search customer and purchase information based on customer 
and purchase id.

e2101439 Eemil Hytönen

*/

using System;
using System.Collections.Generic;
using System.Linq;

// customer information and related methods
class Customer
{
    // customer variables 
    private string name;
    private int id;
    private int[] purchaseIds;

    public Customer(string name, int id, int[] purchaseIds)
    {
        this.name = name;
        this.id = id;
        this.purchaseIds = purchaseIds;
    }

    // methods that return what we need

    public string GetName()
    {
        return name;
    }

    public int GetId()
    {
        return id;
    }

    public int[] GetPurchaseIds()
    {
        return purchaseIds;
    }

    public string GetCustomerInfo()
    {
        // $ string interpolation so you can just slap varibles into {} 
        return $"Customer Name: {GetName()}\nCustomer ID: {GetId()}";
    }
}

// pruchase information and related methods
class Purchase
{
    // product purchase variables. DateTime returns current system time because we add .now parameter later in the
    // code (main section). Products are listen as dictionary key, value and defined in main
    private int purchaseId;
    private DateTime dateTime;
    private Dictionary<string, int> products; // this is where we temporarily store our info (product/amount) as program runs

    public Purchase(int purchaseId, DateTime dateTime, Dictionary<string, int> products)
    {
        this.purchaseId = purchaseId;
        this.dateTime = dateTime;
        this.products = products;
    }
    
    // bunch of methords that just return what we want

    public int GetPurchaseId()
    {
        return purchaseId;
    }

    public DateTime GetDateTime()
    {
        return dateTime;
    }

    public Dictionary<string, int> GetProducts()
    {
        return products;
    }

    public string GetPurchaseInfo()
    {
        string productInfo = "Products:";
        // var means you want to complier to interperate what type of data it is
        foreach (var product in GetProducts())
        {
            // here we retrieve our key (product name) and value (number of purchases) into a list sepereated by \n
            productInfo += $"\n{product.Key}: {product.Value}";
        }
        // return selected Id and check DateTime.Now . After that prints out the list of products/amount we
        // checked in foreach loop above
        return $"Purchase ID: {GetPurchaseId()}\nDate and Time: {GetDateTime()}\n{productInfo}";
    }
}

// this is what we initialize when we search for things. we make it in main and then pass the information....
class CustomerPurchaseHandler
{
    private List<Customer> customers;
    private List<Purchase> purchases;

    public CustomerPurchaseHandler(List<Customer> customers, List<Purchase> purchases)
    {
        //...over here. this is what actualyl itializes the methodwith customer and purchase data.

        this.customers = customers;
        this.purchases = purchases;
    }

    public string SearchCustomerById(int customerId)
    {
        foreach (var customer in customers)
        {
            // checks if the given id matches any known customer if not returns not found
            if (customer.GetId() == customerId)
            {
                // if found prints bunch of words and {GetName()} and {GetId()} in between
                return customer.GetCustomerInfo();
            }
        }
        return "Customer not found.";
    }

    public string SearchPurchaseById(int purchaseId)
    {
        foreach (var purchase in purchases)
        {
            //check if purchaseid matches if not return not found
            if (purchase.GetPurchaseId() == purchaseId)
            {
                // calls the function foreach loop etc. 
                return purchase.GetPurchaseInfo();
            }
        }
        return "Purchase not found.";
    }
}

class Program
{
    // this is where we initialize the customer and purchase data, handle user input and display results 
    static void Main()
    {
        // create customers and purchases
        var customers = new List<Customer>
        {
            new Customer("Eemil", 1, new int[] { }),
            new Customer("Homer Simpson", 2, new int[] { }),
            new Customer("Donald Duck", 3, new int[] { }),
        };

        var purchases = new List<Purchase>
        {
            new Purchase(1, DateTime.Now, new Dictionary<string, int> { { "Laptops", 2 }, { "Mouse", 1 } }),
            new Purchase(2, DateTime.Now, new Dictionary<string, int> { { "Bread", 3 } }),
            new Purchase(3, DateTime.Now, new Dictionary<string, int> { { "TV", 1 } }),
            new Purchase(4, DateTime.Now, new Dictionary<string, int> { { "Potatoes", 2 }, { "Sickle", 1 } }),
            new Purchase(5, DateTime.Now, new Dictionary<string, int> { { "Carrots", 3 } }),
        };

        // this created our customerpurchasehandler and initializes it with our data
        var handler = new CustomerPurchaseHandler(customers, purchases);

        // search for a customer by ID by prompting the user
        Console.WriteLine("Enter a customer ID to search: (1 - 3)");
        int customerId = int.Parse(Console.ReadLine());
        // calls the method and displayes result using the handler we made above
        Console.WriteLine(handler.SearchCustomerById(customerId));

        // search for a purchase by ID by prompting the user
        Console.WriteLine("Enter a purchase ID to search: (1 - 5)");
        int purchaseId = int.Parse(Console.ReadLine());
        // calls the method and displayes result using the handler we made above
        Console.WriteLine(handler.SearchPurchaseById(purchaseId));
    }
}

