//This the namespace (folder) that the compiler should look at
//in order to find classes, like Console referenced in the code but
//are not defined in the current namespace
using System;
//Here we define a folder where the code is.


namespace Example_11
{

namespace main {


class Program
{
static void Main(string[] args)
{
//Here we define a double variable
double number=-1.345789;

//Here we print the text to the standard output
Console.WriteLine("The first C# application!");

//Here we define how numbers must be printed
//out. We display positive, negative and zero values differently
Console.WriteLine("{0:#.#;(#.##);0.00}", number);

//Here we initialize the number variable
number = 0.47;
// Here we display a percentage.
Console.WriteLine("Display a pecentage: {0:#%}", number);

Console.Write("Do you want to say something? ");

//Here we read data from the keyboard
string text=Console.ReadLine();


//Here we concatenate text data and display on the screen
Console.WriteLine("You said: " + text);

return;
}
}

}
}
