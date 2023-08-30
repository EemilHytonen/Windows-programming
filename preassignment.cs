using System;

	class Person
	{
		private string name = "Eemil";
		private double height = 180;
		private double weight = 80;
		
		public void getBMI()
		{
			double BMI;
            double meterHeight = height/100;
			BMI = weight/(meterHeight*meterHeight);
			Console.WriteLine("Person 1 BMI is: " + BMI);
		}
		public void toString()
		{
		    Console.WriteLine("Name: " + name + "\nHeight: " + height + "\nWeight: " + weight);
		}
		
	}
	
	class Program
	{
		static void Main(string[] args)
		{
		    Console.WriteLine("Testi etta kutsuu funktioita eikä kirjoita suoraan funktioita");
		    
			Person myPerson = new Person();
			
			myPerson.getBMI();
			
			myPerson.toString();
		}
	}