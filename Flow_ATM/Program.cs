using System.IO;
using System.Text.Json;

namespace Flow_ATM;

public class User
{
    public string? Name { get; set; }
    public string? AccountNumber { get; set; }
    public double? Balance { get; set; }
}

public class UserServices
{
    public void CheckBalance(User user)
    {
        Console.WriteLine($"Your balance is {user.Balance}");
    }

    public void Deposit(User user, double amount)
    {
        user.Balance += amount;
        Console.WriteLine($"You have deposited {amount}. Your new balance is {user.Balance}");
    }

    public void SendMoney(User sender, string receiverAccountNumber, double amount, List<User> users)
    {
        var receiver = users.Find(u => u.AccountNumber == receiverAccountNumber);
        if (receiver == null)
        {
            Console.WriteLine("Receiver not found");
            return;

        }

        if (receiver.AccountNumber == sender.AccountNumber)
        {
            Console.WriteLine("You cannot send money to yourself");
            return;
        }
        
        if (sender.Balance >= amount)
        {
            sender.Balance -= amount;
            receiver.Balance += amount;
            Console.WriteLine($"You have sent {amount} to {receiver.Name}. Your new balance is {sender.Balance}");
        }
        else
        {
            Console.WriteLine($"Insufficient balance, your balance is {sender.Balance}");
            
        }
    }

    public void Withdraw(User user, double amount)
    {
        if (user.Balance >= amount)
        {
            user.Balance -= amount;
            Console.WriteLine($"You have withdrawn {amount}. Your new balance is {user.Balance}");
        }
        else
        {
            Console.WriteLine($"Insufficient balance, your balance {user.Balance}");
        }
    }
}

public class UsersManagement
{
    string path = "users.json";

    public List<User> LoadUsers()
    {
        List<User> users = new List<User>();

        if(File.Exists(path))
        {
            string[] lines = File.ReadAllLines(path);
            foreach (var line in lines)
            {
                User user = JsonSerializer.Deserialize<User>(line);
                users.Add(user);

            }

            return users;

        }
        else
        {
            Console.WriteLine("No users found");
            return users;
        }

    }

    public void RegisterUser()
    {
        Console.WriteLine("Registering user...");
        Console.WriteLine("Name: ");
        string name = Console.ReadLine() ?? string.Empty;
        if (string.IsNullOrEmpty(name))
        {
            Console.WriteLine("Name cannot be empty");
        }

        Console.WriteLine("Account Number: ");
        string accountNumber = Console.ReadLine() ?? string.Empty;
        if (string.IsNullOrEmpty(accountNumber))
        {
            Console.WriteLine("Account Number cannot be empty");
            return;
        }

        double balance = 0.0;

        List<User> users = LoadUsers();

        if (users.Exists(u => u.AccountNumber == accountNumber))
        {
            Console.WriteLine("User already exists");
            return;
        }

        string userjson = JsonSerializer.Serialize(new User { Name = name, AccountNumber = accountNumber, Balance = balance });

        File.AppendAllText("users.json", userjson + Environment.NewLine);
    }

    public void UpdateUser(User user)
    {
        List<User> users = LoadUsers();
        var userIndex = users.FindIndex(u => u.AccountNumber == user.AccountNumber);
        users[userIndex] = user;

        File.WriteAllText(path, string.Empty);
        foreach (var u in users)
        {
            string userjson = JsonSerializer.Serialize(u);
            File.AppendAllText(path, userjson + Environment.NewLine);
        }
    }

    public void DisplayUsers()
    {
        var users = LoadUsers();
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

        var consoleActive = true;
        while(consoleActive){
            switch (option)
            {
                case 1:
                    // register user
                    usersManagement.RegisterUser();
                    // goto case 2;
                    break;
                case 2:
                    // login
                    Console.WriteLine("Enter account number: ");
                    string accountNumber = Console.ReadLine() ?? string.Empty;

                    var users = usersManagement.LoadUsers();
                    var user = users.Find(u => u.AccountNumber == accountNumber);

                    if (user != null)
                    {
                        UserServices userServices = new UserServices();

                        Console.WriteLine("Welcome " + user.Name);

                        Console.WriteLine("1. Check Balance");
                        Console.WriteLine("2. Deposit");
                        Console.WriteLine("3. Send Money");
                        Console.WriteLine("4. Withdraw");

                        int userOption = Convert.ToInt32(Console.ReadLine());

                        switch (userOption)
                        {
                            case 1:
                                // check balance
                                userServices.CheckBalance(user);
                                break;
                            case 2:
                                // deposit
                                Console.WriteLine("Enter amount: ");
                                double amount = Convert.ToDouble(Console.ReadLine());
                                // user.Deposit(amount);
                                userServices.Deposit(user, amount);

                                break;
                            case 3:
                                // send money
                                Console.WriteLine("Enter receiver account number: ");
                                string receiverAccountNumber = Console.ReadLine();

                                if (string.IsNullOrEmpty(receiverAccountNumber))
                                {
                                    Console.WriteLine("Receiver account number cannot be empty");
                                    break;
                                }

                                if (receiverAccountNumber == user.AccountNumber)
                                {
                                    Console.WriteLine("You cannot send money to yourself");
                                    break;
                                }
                                
                                var receiversList = usersManagement.LoadUsers();

                                if (!receiversList.Exists(u => u.AccountNumber == receiverAccountNumber))
                                {
                                    Console.WriteLine("Receiver not found");
                                    break;
                                }

                                Console.WriteLine("Enter amount: ");
                                double sendAmount = Convert.ToDouble(Console.ReadLine());
                                // user.SendMoney(receiverAccountNumber, sendAmount, usersManagement.users);
                                userServices.SendMoney(user, receiverAccountNumber, sendAmount, receiversList);

                                var receiver = receiversList.Find(u => u.AccountNumber == receiverAccountNumber);

                                // update user balance
                                usersManagement.UpdateUser(user);
                                // update receiver balance
                                usersManagement.UpdateUser(receiver);

                                break;
                            case 4:
                                Console.WriteLine("Enter amount: ");
                                double withdrawAmount = Convert.ToDouble(Console.ReadLine());
                                // user.Withdraw(withdrawAmount);
                                userServices.Withdraw(user, withdrawAmount);
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
                    // display users
                    usersManagement.DisplayUsers();
                    break;
                case 4:
                    // exit
                    Environment.Exit(0);
                    consoleActive = false;
                    break;
                default:
                    Console.WriteLine("Invalid option");
                    break;
            }

        }

    }
}



class Program
{
    static void Main(string[] args)
    {
        Flow_ATM flow_ATM = new Flow_ATM();
        flow_ATM.Run();
    }
}

