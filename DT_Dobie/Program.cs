namespace DT_Dobie;

public class Vehicle
{
    public string Make { get; private set; }
    public string Model { get; private set; }
    public string EngineNumber { get; private set; }
    public double SalePrice { get; private set; }

    public void SetVehicle(string make, string model, string engineNumber, double salePrice)
    {
        Make = make;
        Model = model;
        EngineNumber = engineNumber;
        SalePrice = salePrice;
    }

    public double GetProfit()
    {
        return SalePrice * 0.15;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Vehicle vehicle = new Vehicle();
        vehicle.SetVehicle("Nissan", "Sunny", "EN123456", 20000.0);

        Console.WriteLine($"Profit from the sale of the vehicle: {vehicle.GetProfit()}");
    }
}
