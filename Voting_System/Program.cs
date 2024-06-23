using System;
using System.IO;
using System.Text.Json;

namespace Voting_System;

public class Voter
{
    public string First_Name { get; set; }

    public string Last_Name { get; set; }

    public int ID_Number { get; set; }

    public DateTime Date_Of_Birth { get; set; }

    public string Polling_Station { get; set; }

    public string Gender { get; set; }

}

public class VoterManagement
{
    public string Polling_Station { get; set; }

    Console.WriteLine("Enter Polling_Station: ");

    try
    {
        Polling_Station = Console.ReadLine() ?? throw new ArgumentNullException();
    }
    catch (System.Exception)
    {
        Console.WriteLine("Invalid Polling_Station. Please enter a valid Polling_Station.");
        throw;
    }



    try
    {
        voter.Polling_Station = Console.ReadLine() ?? throw new ArgumentNullException();
    }
    catch (System.Exception)
    {
        Console.WriteLine("Invalid Polling_Station. Please enter a valid Polling_Station.");
        throw;
    }

    string path = "voters.json";

    public List<Voter> LoadVoters()
    {
        List<Voter> votersList = new List<Voter>();

        if (File.Exists(path))
        {
            string [] lines = File.ReadAllLines(path);

            foreach (string line in lines)
            {
                Voter voter = JsonSerializer.Deserialize<Voter>(line);
                votersList.Add(voter);
            }

            return votersList;
        }
        else
        {
            Console.WriteLine("No voters found.");
            return votersList;
        }

    }


    public void RegisterVoter()
    {
        Voter voter = new Voter();

        Console.WriteLine("Register Voter... \n\n");

        //get voter details
        Console.WriteLine("Enter first name: ");
        try
        {
            voter.First_Name = Console.ReadLine() ?? throw new ArgumentNullException();
        }
        catch (System.Exception)
        {
            Console.WriteLine("Invalid name. Please enter a valid name.");
            throw;
        }

        Console.WriteLine("Enter last name: ");
        try
        {
            voter.Last_Name = Console.ReadLine() ?? throw new ArgumentNullException();
        }
        catch (System.Exception)
        {
            Console.WriteLine("Invalid name. Please enter a valid name.");
            throw;
        }

        Console.WriteLine("Enter your ID number: ");

        try
        {
            voter.ID_Number = Convert.ToInt32(Console.ReadLine());
        }
        catch (System.Exception)
        {
            Console.WriteLine("Invalid ID number. Please enter a valid ID number.");
            throw;
        }


        voter.Date_Of_Birth = DateTime.Now;

        List<Voter> voters = LoadVoters();

        if (voters.Exists(v => v.ID_Number == voter.ID_Number))
        {
            Console.WriteLine("Voter already exists.");
            return;
        }

        string voterJson = JsonSerializer.Serialize<Voter>(voter, new JsonSerializerOptions { WriteIndented = true });

        File.AppendAllText("voters.json", voterJson + Environment.NewLine);
    }


    public void DisplayVoters()
    {
        var voters = LoadVoters();

        foreach (var voter in voters)
        {
            Console.WriteLine($"Name: {voter.Name}, Age: {voter.Age}, ID Number: {voter.ID_Number}");
        }
    }

}

public class VoterSystem()
{
    public void Run()
    {
        VoterManagement voterManagement = new VoterManagement();

        Console.WriteLine("Voter System");

        var consoleActive = true;
        while (consoleActive)
        {

            Console.WriteLine("1. Register Voter");
            Console.WriteLine("2. Display Voters");
            Console.WriteLine("3. Exit");

            Console.WriteLine("Enter your choice: ");
            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    voterManagement.RegisterVoter();
                    break;
                case 2:
                    voterManagement.DisplayVoters();
                    break;
                case 3:
                    Environment.Exit(0);
                    consoleActive = false;
                    break;

                default:
                    Console.WriteLine("Invalid choice. Please enter a valid choice.");
                    break;
            }
        }

    }
}

class Program
{
    static void Main(string[] args)
    {

        VoterSystem voterSystem = new VoterSystem();
        voterSystem.Run();
    }
}
