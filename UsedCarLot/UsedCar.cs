using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsedCarLot
{
    public class UsedCar:Car
    {
		private double _mileage;


        public double Mileage { get { return _mileage; } set {_mileage = value; } }

		public UsedCar(string make, string model, int year, decimal price,double mileage) // constructor that we define when we instantiate
		{
			Make = make;
			Model = model;
			Year = year;
			Price = price;
			Mileage = mileage;
		}

		public override string ToString() // overriding the toString method to get the format we want
		{
			return String.Format($"Make: {Make} Model: {Model} Year: {Year} Price: {Price} Mileage: {Mileage}");
		}
	}
}
