using System;

namespace UsedCarLot
{
	public class CarLot
	{

		// List of Cars
		List<Car> listOfVehicles = new List<Car>
		{
		 new UsedCar("Acura", "TSX", 2010, 10000m,80000), // elber
		 new Car("Chevrolet", "Blazer", 2022, 40000m), // eugene
		 new Car("Chevrolet", "TRX", 2020, 75000m), // michael
		 new UsedCar("Scion", "TC", 2012, 3000m, 185000) // troy
		};





		public CarLot()
		{
		}
	}
}

