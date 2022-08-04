namespace UsedCarLot
{
    internal class Program
    {
        static void Main()
        {
            //CarLotApp carLot = new();


            //carLot.PrintCarList();
            //carLot.AddCar();
            //carLot.RemomveCar();
            //carLot.PrintCarListMake("Ford");
            //carLot.PrintCarListYear(2022);
            //carLot.PrintCarListPrice(30000);
            //carLot.PrintCarListUsed();
            //carLot.PrintCarListNew();
            CarLot carLot = new CarLot();
            carLot.ListAllVehicles();


            Console.WriteLine("Which car  would you like to remove?");

            int response = int.Parse(Console.ReadLine());

            carLot.RemoveCar(response);

            carLot.ListAllVehicles();

        }
    }

}