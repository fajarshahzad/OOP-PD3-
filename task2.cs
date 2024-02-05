using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;

namespace task1
{

    class Calculator
    {
        public double Number1;
        public double Number2;

        public Calculator(double number1 = 10, double number2 = 10)
        {
            Number1 = number1;
            Number2 = number2;
        }

        public void SetValues(double number1, double number2)
        {
            Number1 = number1;
            Number2 = number2;
        }

        public double Add()
        {
            return Number1 + Number2;
        }

        public double Subtract()
        {
            return Number1 - Number2;
        }

        public double Multiply()
        {
            return Number1 * Number2;
        }

        public string Divide()
        {
            try
            {
                double result = Number1 / Number2;
                return result.ToString();
            }
            catch (DivideByZeroException)
            {
                return "Error: Division by zero";
            }
        }

        public string Modulo()
        {
            try
            {
                double result = Number1 % Number2;
                return result.ToString();
            }
            catch (DivideByZeroException)
            {
                return "Error: Modulo by zero";
            }
        }
        public double Sqrt(double number)
        {
            if (number < 0)
            {
                return double.NaN; // NaN for negative numbers
            }
            return Math.Sqrt(number);
        }
        public double Exp(double exponent)
        {
            return Math.Exp(exponent);//e^ the number entered by the user
        }

        public double Log(double number)
        {
            if (number <= 0)
            {
                return double.NaN; // NaN for non-positive numbers
            }
            return Math.Log(number);
        }
        public double Sin(double degrees)
        {
            return Math.Sin(degrees * (Math.PI / 180.0));
        }

        public double Cos(double degrees)
        {
            return Math.Cos(degrees * (Math.PI / 180.0));
        }

        public double Tan(double degrees)
        {
            return Math.Tan(degrees * (Math.PI / 180.0));
        }
    }

    class Program
    {
        static void Main()
        {
            Calculator calculator = null;
            int option = 0;
            double result = 0;
            while (option != 14)
            {
                Console.Clear();
                option = display_menu();
                if (option == 1)
                {
                    Console.Clear();
                    // Create a Single Object of Calculator
                    calculator = new Calculator();
                    Console.WriteLine("Calculator object created with default values (10 and 10).");

                }
                if (option == 2)
                {
                    if (calculator != null)
                    {
                        Console.Clear();
                        // Change Values of Attributes
                        Console.Write("Enter new value for number1: ");
                        double newNumber1 = double.Parse(Console.ReadLine());
                        Console.Write("Enter new value for number2: ");
                        double newNumber2 = double.Parse(Console.ReadLine());
                        calculator.SetValues(newNumber1, newNumber2);
                        Console.WriteLine("Values changed successfully.");

                    }
                    else
                    {
                        Console.WriteLine("Calculator object not created yet. Create one first.");

                    }


                }
                if (calculator != null)
                {
                    if (option == 3)
                    {
                        Console.Clear();
                        result = calculator.Add();
                        Console.WriteLine("The Addition of two numbers is: " + result);
                    }
                    if (option == 4)
                    {
                        Console.Clear();
                        result = calculator.Subtract();
                        Console.WriteLine("The Subtraction of two numbers is: " + result);
                    }
                    if (option == 5)
                    {
                        Console.Clear();
                        result = calculator.Multiply();
                        Console.WriteLine("The Multiplication of the numbers is: " + result);
                    }
                    if (option == 6)
                    {
                        Console.Clear();
                        Console.WriteLine("The Divison of two numbers is: " + calculator.Divide());
                    }
                    if (option == 7)
                    {
                        Console.Clear();
                        Console.WriteLine("The Modulo of two numbers is: " + calculator.Modulo());
                    }
                    if (option == 8)
                    {
                        Console.Clear();
                        Console.Write("Enter a number for square root: ");
                        double sqrtInput = double.Parse(Console.ReadLine());
                        Console.WriteLine($"Square Root: {calculator.Sqrt(sqrtInput)}");
                    }
                    if(option==9)
                    {
                        Console.Clear();
                        Console.WriteLine("Enter a number for the exponent: ");
                        double expInput = double.Parse(Console.ReadLine());
                        Console.WriteLine($"Exponential Value: {calculator.Exp(expInput)}");
                    }
                    if(option==10)
                    {
                        Console.Clear();
                        Console.WriteLine("Enter the number for Logarithm: ");
                        double logInput = double.Parse(Console.ReadLine());
                        Console.WriteLine($"The Logarithimic value of the number is: {calculator.Log(logInput)}");
                    }
                    if(option==11)
                    {
                        Console.Clear();
                        Console.WriteLine("Enter the angle in degrees: ");
                        double angle = double.Parse(Console.ReadLine());
                        Console.WriteLine($"The sine of the angle {angle} is {calculator.Sin(angle)}");
                    }
                    if (option == 12)
                    {
                        Console.Clear();
                        Console.WriteLine("Enter the angle in degrees: ");
                        double angle = double.Parse(Console.ReadLine());
                        Console.WriteLine($"The cosine of the angle {angle} is {calculator.Cos(angle)}");
                    }
                    if(option==13)
                    {
                        Console.Clear();
                        Console.WriteLine("Enter the angle in degrees: ");
                        double angle = double.Parse(Console.ReadLine());
                        Console.WriteLine($"The tangent of the angle {angle} is {calculator.Tan(angle)}");
                    }
                    if(option==14)
                    {
                        Console.Clear();
                        Console.WriteLine("Exiting the Program. GoodBye!");
                    }
                }
                else
                {
                    Console.WriteLine("Calculator object not created yet. Create one first.");
                }
                Console.ReadKey();
            }



        }

        static int display_menu()
        {
            Console.WriteLine("Menu of the calculator:)");
            Console.WriteLine("1.  Create a Single Object of Calculator");
            Console.WriteLine("2.  Change Values of Attributes");
            Console.WriteLine("3.  Add");
            Console.WriteLine("4.  Subtract");
            Console.WriteLine("5.  Multiply");
            Console.WriteLine("6.  Divide");
            Console.WriteLine("7.  Modulo");
            Console.WriteLine("8.  Square Root");
            Console.WriteLine("9.  Exponential");
            Console.WriteLine("10. Logarithm");
            Console.WriteLine("11. Sine");
            Console.WriteLine("12. Cosine");
            Console.WriteLine("13. Tangent");
            Console.WriteLine("14. Exit");
        again:
            Console.Write("Enter your choice (1-14): ");
            int choice = int.Parse(Console.ReadLine());
            if (choice < 1 || choice > 14)
            {
                Console.WriteLine("Invalid input. Please enter a number.");
                goto again;
            }
            return choice;
        }
    }

}

