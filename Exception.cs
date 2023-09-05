



using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Employee> employees = new List<Employee>();
        
        while (true)
        {
            Console.WriteLine("Menu:");
            Console.WriteLine("1. Enter new Employee");
            Console.WriteLine("2. List Employees");
            Console.WriteLine("3. Exit");
            Console.Write("Enter your choice: ");
            
            int choice = int.Parse(Console.ReadLine());
            
            switch (choice)
            {
                case 1:
                    try
                    {
                        Console.Write("Enter Employee name: ");
                        string name = Console.ReadLine();
                        
                        if (employees.Exists(e => e.Name == name))
                        {
                            throw new DuplicateNameException();
                        }
                        
                        Console.Write("Enter Employee age: ");
                        int age = int.Parse(Console.ReadLine());
                        
                        if (age < 18)
                        {
                            throw new AgeException("Children not allowed as an Employee");
                        }
                        else if (age > 60)
                        {
                            throw new AgeException("Seniors not allowed as an Employee");
                        }
                        else if (age > 100)
                        {
                            throw new AgeException("Purvaj not allowed as an Employee");
                        }
                        
                        employees.Add(new Employee(name, age));
                        Console.WriteLine("Employee added successfully.");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error: {ex.Message}");
                    }
                    break;
                    
                case 2:
                    Console.WriteLine("List of Employees:");
                    foreach (var employee in employees)
                    {
                        Console.WriteLine($"Name: {employee.Name}, Age: {employee.Age}");
                    }
                    break;
                    
                case 3:
                    Console.WriteLine("Exiting program.");
                    Environment.Exit(0);
                    break;
                    
                default:
                    Console.WriteLine("Invalid choice. Please select a valid option.");
                    break;
            }
        }
    }
}

class Employee
{
    public string Name { get; set; }
    public int Age { get; set; }

    public Employee(string name, int age)
    {
        Name = name;
        Age = age;
    }
}

class AgeException : Exception
{
    public AgeException(string message) : base(message)
    {
    }
}

class DuplicateNameException : Exception
{
    public DuplicateNameException() : base("Duplicate Name: Not allowed to enter twice (Need double Salary??)")
    {
    }
}












using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            Console.WriteLine("Enter a comma-separated list of topic name and hours" +
                " (e.g., Java 24, JEE 10, JME 12):");
            string input = Console.ReadLine();

            string[] inputArray = input.Split(',');

            Dictionary<string, int> topics = new Dictionary<string, int>();

            // Parse the input into topic name and hours, and add to the dictionary
            for (int i = 0; i < inputArray.Length; i += 2)
            {
                string topic = inputArray[i].Trim();
                int hours = int.Parse(inputArray[i + 1].Trim());
                topics[topic] = hours;
            }

            // Calculate topics covered day-wise
            int hoursInADay = 8;

            foreach (var topic in topics)
            {
                int days = (int)Math.Ceiling((double)topic.Value / hoursInADay);
                Console.WriteLine($"{topic.Key}: {days} days training");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }
}
