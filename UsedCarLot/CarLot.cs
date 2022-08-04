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

		public void AddCar(Car c)
		{
			//Console.WriteLine("What is the make?");
			//string make = Console.ReadLine();
			//Console.WriteLine("What is the model?");
			//string model = Console.ReadLine();
			//Console.WriteLine("What is the year?");
			//string year = ;
			//Console.WriteLine("What is the price?");
			//string price = Console.ReadLine();
			//Console.WriteLine("What is the mileage?");
			//string uOrN = Console.ReadLine();


			//Console.WriteLine("Is it a new car?");

   //         string uOrN = Console.ReadLine();

   //         if (uOrN.ToLower() == "yes")
   //         {

   //         }

			
			listOfVehicles.Add(c);
		}
		public void RemoveCar(int index)
		{
			

			listOfVehicles.RemoveAt(--index);
		}

		public void ListAllVehicles() 
		{
			int i = 1;
            foreach (Car c in listOfVehicles)
            {
                Console.WriteLine("(" + i++ + ") " + c.ToString());
            }
		}

		public CarLot()
		{
		}
	}
}

