using System.Reflection;

namespace UsedCarLot
{
    public class CarLotApp
    {
        private string newCarPath = FindApplicationFile("NewCars.txt").ToString();  //Points to the new car list
        private string usedCarPath = FindApplicationFile("UsedCars.txt").ToString(); //Points to the used car list
        public List<Car> carList = new(); // List of all cars that are available

        /// <summary>
        /// Starts a new car lot and adds the cars in the database
        /// </summary>
        public CarLotApp()
        {
            LoadCarList();
        }

        /// <summary>
        /// Loads the cars from the database to a list
        /// </summary>
        private void LoadCarList()
        {
            string[] newCarTextDatabase = File.ReadAllLines(newCarPath);
            string[] usedCarTextDatabase = File.ReadAllLines(usedCarPath);

            foreach(string line in newCarTextDatabase)
            {
                string[] entries = line.Split(',');
                carList.Add(new Car(entries[0], entries[1], int.Parse(entries[2]), decimal.Parse(entries[3])));
            }
            foreach(string line in usedCarTextDatabase)
            {
                string[] entries = line.Split(',');
                carList.Add(new UsedCar(entries[0], entries[1], int.Parse(entries[2]), decimal.Parse(entries[3]), double.Parse(entries[4])));
            }
            SortCarList();
        }

        /// <summary>
        /// Sorts the list of cars
        /// </summary>
        private void SortCarList()
        {
            carList = carList.OrderBy(x => x.Make).ThenBy(x => x.Model).ThenBy(x => x.Price).ToList();
            SaveCarDatabase();
        }

        /// <summary>
        /// Saves the list of cars to the database
        /// </summary>
        private void SaveCarDatabase()
        {
            List<string> outputNewCar = new();
            List<string> outputCarUsed = new();
            foreach(Car vehicle in carList)
            {
                if(vehicle is UsedCar usedCar)
                {
                    outputCarUsed.Add($"{usedCar.Make},{usedCar.Model},{usedCar.Year},{usedCar.Price},{usedCar.Mileage}");
                    continue;
                }
                outputNewCar.Add($"{vehicle.Make},{vehicle.Model},{vehicle.Year},{vehicle.Price}");
            }
            File.WriteAllLines(newCarPath, outputNewCar);
            File.WriteAllLines(usedCarPath, outputCarUsed);
        }

        /// <summary>
        /// Prints all the cars on the list with an index number
        /// </summary>
        public void PrintCarList()
        {
            int index = 1;
            foreach(Car car in carList)
            {
                Console.WriteLine($"{index}: {car}");
                index++;
            }
        }

        /// <summary>
        /// Prints all the cars of the matching make
        /// </summary>
        /// <param name="Make of the car to print"></param>
        public void PrintCarListMake(string make)
        {
            carList.Where(x => x.Make == make).ToList().ForEach(c => Console.WriteLine(c));
        }

        /// <summary>
        /// Prints all the cars of the matching year
        /// </summary>
        /// <param name="what year of car to print"></param>
        public void PrintCarListYear(int year)
        {
            carList.Where(x => x.Year == year).ToList().ForEach(c => Console.WriteLine(c));
        }

        /// <summary>
        /// Prints all the cars that are lower then the price
        /// </summary>
        /// <param name="prints all cars lower then this price"></param>
        public void PrintCarListPrice(decimal price)
        {
            carList.Where(x => x.Price <= price).ToList().ForEach(c => Console.WriteLine(c));
        }

        /// <summary>
        /// Prints a list of used cars
        /// </summary>
        public void PrintCarListUsed()
        {
            foreach(Car vehicle in carList)
            {
                if(vehicle is UsedCar)
                {
                    Console.WriteLine(vehicle);
                }
            }
        }

        /// <summary>
        /// Prints a list of new cars
        /// </summary>
        public void PrintCarListNew()
        {
            foreach(Car vehicle in carList)
            {
                if(vehicle is not UsedCar)
                {
                    Console.WriteLine(vehicle);
                }
            }
        }

        /// <summary>
        /// Allows the user to buy a car
        /// </summary>
        public void RemomveCar()
        {
            string userInput;
            do
            {
                Console.Clear();
                PrintCarList();
                Console.WriteLine();
                Console.Write("Please enter the index of the car you want to buy or exit: ");
                userInput = Console.ReadLine().Trim();
                if(int.TryParse(userInput, out int index) && --index < carList.Count)
                {
                    Console.Clear();
                    Console.WriteLine(carList.ElementAt(index));
                    Console.WriteLine();
                    Console.Write($"Are you sure you would like to buy this car Y/N? ");
                    string confirmation = Console.ReadLine().ToLower().Trim();
                    if(confirmation != string.Empty && "yes".StartsWith(confirmation))
                    {
                        Console.Clear();
                        carList.RemoveAt(index);
                        SaveCarDatabase();
                        Console.WriteLine("Excellent!  Our finance department will be in touch shortly.");
                        return;
                    }
                    Console.Clear();
                    Console.WriteLine("That's too bad.");
                    return;
                }
                else if("exit".Equals(userInput.ToLower()))
                {
                    return;
                }
                Console.WriteLine($"Sorry {userInput} is not a valid input");
                Console.WriteLine("Press any key to continue.");
                Console.ReadKey();
            } while(true);
        }

        /// <summary>
        /// Adds a car to inventory
        /// </summary>
        public void AddCar()
        {
            string make;
            string model;
            int year;
            decimal price;
            double mileage;

            do
            {
                Console.Clear();
                Console.Write("Please enter the make of the car or exit: ");
                make = Console.ReadLine().Trim();
                if("exit".Equals(make.ToLower()))
                {
                    return;
                }
                else if(make != string.Empty && !make.Contains(','))
                {
                    break;
                }
                Console.WriteLine("Entry is empty or invalid input.");
                Console.WriteLine("Press any key to continue.");
                Console.ReadKey();
            } while(true);

            do
            {
                Console.Clear();
                Console.Write("Please enter the model of the car or exit: ");
                model = Console.ReadLine().Trim();
                if("exit".Equals(make.ToLower()))
                {
                    return;
                }
                else if(model != string.Empty && !model.Contains(','))
                {
                    break;
                }
                Console.WriteLine("Entry is empty or invalid input.");
                Console.WriteLine("Press any key to continue.");
                Console.ReadKey();
            } while(true);

            do
            {
                Console.Clear();
                Console.Write("Please enter the year of the car or exit: ");
                string userInput = Console.ReadLine().Trim();
                if("exit".Equals(userInput.ToLower()))
                {
                    return;
                }
                else if(userInput != string.Empty && int.TryParse(userInput, out int yearArg))
                {
                    if(yearArg >= 1886 && yearArg <= DateTime.Now.Year + 1)
                    {
                        year = yearArg;
                        break;
                    }
                }
                Console.WriteLine("Entry is empty or invalid input.");
                Console.WriteLine("Press any key to continue.");
                Console.ReadKey();
            } while(true);

            do
            {
                Console.Clear();
                Console.Write("Please enter the price of the car or exit: ");
                string userInput = Console.ReadLine().Trim();
                if("exit".Equals(userInput.ToLower()))
                {
                    return;
                }
                else if(userInput != string.Empty && decimal.TryParse(userInput, out decimal priceArg))
                {
                    if(priceArg >= 1000 && priceArg <= 500000)
                    {
                        price = priceArg;
                        break;
                    }
                }
                Console.WriteLine("Entry is empty or invalid input.");
                Console.WriteLine("Press any key to continue.");
                Console.ReadKey();
            } while(true);

            do
            {
                Console.Clear();
                Console.Write("Please enter the mileage of the car or exit: ");
                string userInput = Console.ReadLine().Trim();
                if("exit".Equals(userInput.ToLower()))
                {
                    return;
                }
                else if(userInput != string.Empty && double.TryParse(userInput, out double mileageArg))
                {
                    if(mileageArg >= 0 && mileageArg <= 1000000)
                    {
                        mileage = mileageArg;
                        break;
                    }
                }
                Console.WriteLine("Entry is empty or invalid input.");
                Console.WriteLine("Press any key to continue.");
                Console.ReadKey();
            } while(true);

            if(mileage < 50)
            {
                Car newCar = new(make, model, year, price);
                carList.Add(newCar);
                Console.WriteLine("New car add.");
            }
            else
            {
                UsedCar usedCar = new(make, model, year, price, mileage);
                carList.Add(usedCar);
                Console.WriteLine("Used car added");
            }
            SortCarList();
        }

        /// <summary>
        /// Moves up one directory at a time until it finds the file its looking for
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns>The file path if found</returns>
        public static FileInfo FindApplicationFile(string fileName)
        {
            string startPath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), fileName);
            FileInfo file = new FileInfo(startPath);
            while(!file.Exists)
            {
                if(file.Directory.Parent == null)
                {
                    return null;
                }
                DirectoryInfo parentDir = file.Directory.Parent;
                file = new FileInfo(Path.Combine(parentDir.FullName, file.Name));
            }
            return file;
        }
    }
}