using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsedCarLot
{
    public class UsedCar:Car
    {
        public double Mileage { get; set; }

		public UsedCar(string make, string model, int year, decimal price,double mileage) // constructor that we define when we instantiate
		{
			Make = make;
			Model = model;
			Year = year;
			Price = price;
			Mileage = mileage;
		}
	}
}
