using System;
namespace UsedCarLot
{
	public class Car
	{
		public Car() // constructor w default values
		{
			Make = String.Empty;
			Model = String.Empty;
			Year = 0;
			Price = 0;
		}
		public Car(string make, string model, int year, decimal price) // constructor that we define when we instantiate
		{
			Make = make;
			Model = model;
			Year = year;
			Price = price;

		}
		//properties
		public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public decimal Price { get; set; }

		//public override string ToString() // overriding the toString method to get the format we want
  //      {
		//	return 
  //      }
		 
    }
}

