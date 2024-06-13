namespace First_Console;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter first number: ");
        int a = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Enter second number: ");
        int b = Convert.ToInt32(Console.ReadLine());

        int sum = a + b;
        int product = a * b;
        int difference = a - b;
        int division = a / b;
        int modulus = a % b;

        Console.WriteLine("Hello, World!");
        Console.WriteLine("Addition of a and b is: " + sum);
        Console.WriteLine("Product of a and b is: " + product);
        Console.WriteLine("Difference of a and b is: " + difference);
        Console.WriteLine("Division of a and b is: " + division);
        Console.WriteLine("Modulus of a and b is: " + modulus);
        
    }
}
