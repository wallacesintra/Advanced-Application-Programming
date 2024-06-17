namespace Flow_ATM;

public class User
{
    public string Name;
    public string AccountNumber;
    public double Balance;


    public void CheckBalance()
    {
        Console.WriteLine($"Your balance is: {Balance}");
    }

    public void Deposit(double amount)
    {
        Console.WriteLine("Depositing money...");
        Balance += amount;
    }



    public void SendMoney(string accountNumber, double amount)
    {
        Console.WriteLine("Sending money...");

        var user = users.Find(u => u.AccountNumber == accountNumber);

        if (user != null)
        {
            if (Balance >= amount)
            {
                Balance -= amount;
                user.Balance += amount;
            }
            else
            {
                Console.WriteLine("Insufficient funds");
            }
        }
        else
        {
            Console.WriteLine("User not found");
        }
    

    }
    public void Withdraw(double amount)
    {
        Console.WriteLine("Withdrawing money...");
        if (Balance >= amount)
        {
            Balance -= amount;
        }
        else
        {
            Console.WriteLine("Insufficient funds");
        }
    }


}

public class UsersManagement
{
    public List<User> users = new List<User>();
    // List<User> users = new List<User>();

    public void RegisterUser()
    {
        Console.WriteLine("Registering user...");
        Console.WriteLine("Name: ");
        string name = Console.ReadLine();

        Console.WriteLine("Account Number: ");
        string accountNumber = Console.ReadLine();

        double balance = 0.0;

        users.Add(new User { Name = name, AccountNumber = accountNumber, Balance = balance });
    }


    public void DisplayUsers()
    {
        foreach (var user in users)
        {
            Console.WriteLine($"Name: {user.Name}, Account Number: {user.AccountNumber}, Balance: {user.Balance}");
        }
    }
}

public class Flow_ATM
{
    public void Run()
    {
        Console.WriteLine("Hello, Welcome to Flow ATM!");

        UsersManagement usersManagement = new UsersManagement();


        Console.WriteLine("1. Register User");
        Console.WriteLine("2. Login");
        Console.WriteLine("3. Display Users");
        Console.WriteLine("4. Exit");

        int option = Convert.ToInt32(Console.ReadLine());

        switch (option)
        {
            case 1:
                usersManagement.RegisterUser();
                break;
            case 2:
                Console.WriteLine("Enter account number: ");
                string accountNumber = Console.ReadLine();

                var user = usersManagement.users.Find(u => u.AccountNumber == accountNumber);

                if (user != null)
                {

                    Console.WriteLine("Welcome " + user.Name);

                    Console.WriteLine("1. Check Balance");
                    Console.WriteLine("2. Deposit");
                    Console.WriteLine("3. Send Money");
                    Console.WriteLine("4. Withdraw");

                    int userOption = Convert.ToInt32(Console.ReadLine());

                    switch (userOption)
                    {
                        case 1:
                            user.CheckBalance();
                            break;
                        case 2:
                            Console.WriteLine("Enter amount: ");
                            double amount = Convert.ToDouble(Console.ReadLine());
                            user.Deposit(amount);
                            break;
                        case 3:
                            Console.WriteLine("Enter account number: ");
                            string receiverAccountNumber = Console.ReadLine();
                            Console.WriteLine("Enter amount: ");
                            double sendAmount = Convert.ToDouble(Console.ReadLine());
                            user.SendMoney(receiverAccountNumber, sendAmount);
                            break;
                        case 4:
                            Console.WriteLine("Enter amount: ");
                            double withdrawAmount = Convert.ToDouble(Console.ReadLine());
                            user.Withdraw(withdrawAmount);
                            break;
                        default:
                            Console.WriteLine("Invalid option");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("User not found");
                }
                break;
            case 3:
                usersManagement.DisplayUsers();
                break;
            case 4:
                Environment.Exit(0);
                break;
            default:
                Console.WriteLine("Invalid option");
                break;
        }
    }
}



class Program
{
    static void Main(string[] args)
    {
        // Console.WriteLine("Hello, World!");
        // List<User> users = new List<User>();
        Flow_ATM flow_ATM = new Flow_ATM();
        flow_ATM.Run();
    }
}
