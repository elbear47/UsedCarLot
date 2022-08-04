using System;
namespace UsedCarLot
{
	public class Car
	{
		private string _make;
		private string _model;
		private int _year;
		private decimal _price;
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

        public override string ToString() // overriding the toString method to get the format we want
        {
			return String.Format($"Make: {Make} Model: {Model} Year: {Year} Price: {Price}");
        }
		//used car class constructor

		//public UsedCar(string _make, string _model, int _year, decimal _price, double _mileage) : base(_make, _model, _year, _price) { mileage = _mileage; }


	}
}

