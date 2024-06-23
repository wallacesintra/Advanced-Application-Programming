namespace Bonga_reward;

public class Subscriber
{
    public string Name { get; set; }
    public string PhoneNumber { get; set; }
    public double AirtimeAmount { get; set; }

    public Subscriber(string name, string phoneNumber, double airtimeAmount)
    {
        Name = name;
        PhoneNumber = phoneNumber;
        AirtimeAmount = airtimeAmount;
    }

    public int ComputeBonusPoints()
    {
        if (AirtimeAmount >= 2000)
        {
            return 500;
        }
        else if (AirtimeAmount >= 1000)
        {
            return 300;
        }
        else if (AirtimeAmount >= 500)
        {
            return 100;
        }
        else if (AirtimeAmount >= 100)
        {
            return 50;
        }
        else
        {
            return 0;
        }
    }

    public void DisplayInformation()
    {
        Console.WriteLine($"{Name}: (PHONE NO: {PhoneNumber}):  AWARDED {ComputeBonusPoints()} bonus points, STAY WITH SAFARICOM. THE BETTER OPTION.");
    }
}

class Program
{
    static void Main(string[] args)
    {
        Subscriber subscriber = new Subscriber("Wallace Wahongo", "0712345678", 1500);
        subscriber.DisplayInformation();
    }
}
