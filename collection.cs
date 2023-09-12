


using System;
using System.Collections.Generic;
using System.IO;

class Emp
{
    public int Id { get; set; }
    public string Name { get; set; }

    public Emp(int id, string name)
    {
        Id = id;
        Name = name;
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Prepare a list of 10 employees (coded)
        List<Emp> employees = new List<Emp>
        {
            new Emp(1, "John"),
            new Emp(2, "Alice"),
            new Emp(3, "Bob"),
            new Emp(4, "Eve"),
            new Emp(5, "Charlie"),
            new Emp(6, "David"),
            new Emp(7, "Emily"),
            new Emp(8, "Frank"),
            new Emp(9, "Grace"),
            new Emp(10, "Helen")
        };

        Console.Write("Enter your employee ID: ");
        if (int.TryParse(Console.ReadLine(), out int empID))
        {
            Emp employee = employees.Find(emp => emp.Id == empID);
            if (employee != null)
            {
                // Get the current date and time
                DateTime currentDateTime = DateTime.Now;

                // Create a formatted log message
                string logMessage = $"Emp with ID: {employee.Id} having name {employee.Name} has logged in at {currentDateTime}";

                // Append the log message to the "LoginDetails.txt" file in the "Ponica" folder
                string folderPath = "C:\\Ponica"; // Change this path to your desired folder
                string filePath = Path.Combine(folderPath, "LoginDetails.txt");

                try
                {
                    // Ensure the folder exists
                    Directory.CreateDirectory(folderPath);

                    // Append the log message to the file
                    File.AppendAllText(filePath, logMessage + Environment.NewLine);

                    Console.WriteLine("Login details have been logged successfully.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error writing to the file: {ex.Message}");
                }
            }
            else
            {
                Console.WriteLine("Employee not found with the provided ID.");
            }
        }
        else
        {
            Console.WriteLine("Invalid employee ID.");
        }
    }
}








using System;
using System.IO;
using System.Text.RegularExpressions;

class Program
{
    static void Main(string[] args)
    {
        if (args.Length != 1)
        {
            Console.WriteLine("Usage: CheckFile <filename.cs>");
            return;
        }

        string inputFileName = args[0];

        if (!inputFileName.EndsWith(".cs", StringComparison.OrdinalIgnoreCase))
        {
            Console.WriteLine("Error: The file is not a C# source file (extension is not .cs).");
            return;
        }

        string outputFileName;

        // Read the content of the input file
        string fileContent;
        try
        {
            fileContent = File.ReadAllText(inputFileName);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error reading the file: {ex.Message}");
            return;
        }

        // Check if the file content contains "Main(string[] args)" or "Main()"
        if (Regex.IsMatch(fileContent, @"\bMain\s*\(\s*string\[\]\s*args\s*\)|\bMain\s*\(\s*\)", RegexOptions.Multiline))
        {
            // Create an executable file
            outputFileName = Path.ChangeExtension(inputFileName, "exe");

            try
            {
                File.WriteAllText(outputFileName, fileContent);
                Console.WriteLine("Compiled successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error creating the executable file: {ex.Message}");
            }
        }
        else
        {
            // Create a mydll file
            outputFileName = Path.ChangeExtension(inputFileName, "mydll");

            try
            {
                File.WriteAllText(outputFileName, fileContent);
                Console.WriteLine("Compiled successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error creating the mydll file: {ex.Message}");
            }
        }

        // Copy the content of the input file to the output file
        try
        {
            File.Copy(inputFileName, outputFileName, true);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error copying file content: {ex.Message}");
        }
    }
}






using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("Main Menu:");
            Console.WriteLine("1. Using File");
            Console.WriteLine("2. Using FileStream");
            Console.WriteLine("3. Using StreamReader and StreamWriter");
            Console.WriteLine("4. Exit");
            Console.Write("Enter your choice (1/2/3/4): ");

            if (int.TryParse(Console.ReadLine(), out int mainChoice))
            {
                switch (mainChoice)
                {
                    case 1:
                        FileMenu();
                        break;
                    case 2:
                        FileStreamMenu();
                        break;
                    case 3:
                        StreamReaderStreamWriterMenu();
                        break;
                    case 4:
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please enter a valid option (1/2/3/4).");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid option (1/2/3/4).");
            }
        }
    }

    static void FileMenu()
    {
        string fileName = "FileMenu.txt";

        while (true)
        {
            Console.WriteLine("\nFile Menu:");
            Console.WriteLine("1. Write to File");
            Console.WriteLine("2. Read from the File");
            Console.WriteLine("3. Go to Main Menu");
            Console.Write("Enter your choice (1/2/3): ");

            if (int.TryParse(Console.ReadLine(), out int choice))
            {
                switch (choice)
                {
                    case 1:
                        WriteToFile(fileName);
                        break;
                    case 2:
                        ReadFromFile(fileName);
                        break;
                    case 3:
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please enter a valid option (1/2/3).");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid option (1/2/3).");
            }
        }
    }

    static void WriteToFile(string fileName)
    {
        Console.WriteLine("\nEnter text (type 'done' to finish):");
        string userInput;

        using (StreamWriter writer = new StreamWriter(fileName))
        {
            while (true)
            {
                userInput = Console.ReadLine();
                if (userInput.ToLower() == "done")
                    break;

                writer.WriteLine(userInput);
            }
        }

        Console.WriteLine("Text written to the file successfully.");
    }

    static void ReadFromFile(string fileName)
    {
        if (!File.Exists(fileName))
        {
            Console.WriteLine("The file does not exist. Please write to the file first.");
            return;
        }

        Console.WriteLine("\nFile Content:");

        using (StreamReader reader = new StreamReader(fileName))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                Console.WriteLine(line);
            }
        }
    }

    static void FileStreamMenu()
    {
        // Implement FileStream menu here
        Console.WriteLine("File Stream Menu (Not implemented yet).");
    }

    static void StreamReaderStreamWriterMenu()
    {
        // Implement StreamReader and StreamWriter menu here
        Console.WriteLine("StreamReader and StreamWriter Menu (Not implemented yet).");
    }
}





using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        string fileName = "UserInput.txt";
        string userInput;
        int wordCount = 0;

        Console.WriteLine("Enter text (type 'done' to finish):");

        // Write user input to the file until "done" is entered
        using (StreamWriter writer = new StreamWriter(fileName))
        {
            while (true)
            {
                userInput = Console.ReadLine();
                if (userInput.ToLower() == "done")
                    break;

                writer.WriteLine(userInput);
            }
        }

        // Read the file and count words
        using (StreamReader reader = new StreamReader(fileName))
        {
            string fileContent = reader.ReadToEnd();
            string[] words = fileContent.Split(new[] { ' ', '\t', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
            wordCount = words.Length;
        }

        Console.WriteLine($"\nNumber of words in the file: {wordCount}\n");

        // Display the file content
        Console.WriteLine("File Content:");
        using (StreamReader reader = new StreamReader(fileName))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                Console.WriteLine(line);
            }
        }

        // Optionally, you can delete the file after displaying its content
        File.Delete(fileName);
    }
}
 




using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("Menu:");
            Console.WriteLine("1. Write to a file");
            Console.WriteLine("2. Read from a file");
            Console.WriteLine("3. Exit");
            Console.Write("Enter your choice (1/2/3): ");

            int choice;
            if (int.TryParse(Console.ReadLine(), out choice))
            {
                switch (choice)
                {
                    case 1:
                        WriteToFile();
                        break;
                    case 2:
                        ReadFromFile();
                        break;
                    case 3:
                        return; // Exit the program
                    default:
                        Console.WriteLine("Invalid choice. Please enter a valid option (1/2/3).");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid option (1/2/3).");
            }
        }
    }

    static void WriteToFile()
    {
        Console.WriteLine("Enter text (type 'done' to finish and save):");

        using (StreamWriter writer = new StreamWriter("textfile.txt"))
        {
            while (true)
            {
                string input = Console.ReadLine();
                if (input.ToLower() == "done")
                    break;

                writer.WriteLine(input);
            }
        }

        Console.WriteLine("Text written to the file successfully.");
    }

    static void ReadFromFile()
    {
        try
        {
            string[] lines = File.ReadAllLines("textfile.txt");
            Console.WriteLine($"Contents of the file (Number of Words: {CountWords(lines)}):");
            foreach (string line in lines)
            {
                Console.WriteLine(line);
            }
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("The file does not exist.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }

    static int CountWords(string[] lines)
    {
        int wordCount = 0;
        foreach (string line in lines)
        {
            string[] words = line.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            wordCount += words.Length;
        }
        return wordCount;
    }
}







using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        Dictionary<string, List<string>> dictionary = new Dictionary<string, List<string>>();

        // Add words and their meanings to the dictionary
        AddWordMeaning(dictionary, "apple", new List<string> { "a fruit", "a tech company" });
        AddWordMeaning(dictionary, "book", new List<string> { "a written or printed work", "to reserve" });
        AddWordMeaning(dictionary, "bank", new List<string> { "a financial institution", "the side of a river" });

        // Display the words and their meanings in sorted order
        DisplayDictionary(dictionary);
        
        // Search for a word and display its meanings
        Console.Write("\nEnter a word to search: ");
        string searchWord = Console.ReadLine().ToLower();

        if (dictionary.ContainsKey(searchWord))
        {
            List<string> meanings = dictionary[searchWord];
            Console.WriteLine($"\nMeanings of '{searchWord}':");
            foreach (var meaning in meanings)
            {
                Console.WriteLine(meaning);
            }
        }
        else
        {
            Console.WriteLine($"\n'{searchWord}' not found in the dictionary.");
        }
    }

    static void AddWordMeaning(Dictionary<string, List<string>> dictionary, string word, List<string> meanings)
    {
        word = word.ToLower(); // Convert word to lowercase for case-insensitive search
        dictionary[word] = meanings;
    }

    static void DisplayDictionary(Dictionary<string, List<string>> dictionary)
    {
        var sortedDictionary = dictionary.OrderBy(pair => pair.Key);
        
        Console.WriteLine("Dictionary:");
        foreach (var entry in sortedDictionary)
        {
            Console.WriteLine($"Word: {entry.Key}");
            Console.WriteLine("Meanings:");
            foreach (var meaning in entry.Value)
            {
                Console.WriteLine($"- {meaning}");
            }
            Console.WriteLine();
        }
    }
}







using System;
using System.Collections.Generic;
using System.Linq;

class Employee
{
    public string Name { get; set; }
    public string Designation { get; set; }

    public Employee(string name, string designation)
    {
        Name = name;
        Designation = designation;
    }

    // Override GetHashCode and Equals to compare employees by name and designation
    public override int GetHashCode()
    {
        return Name.GetHashCode() ^ Designation.GetHashCode();
    }

    public override bool Equals(object obj)
    {
        if (obj is Employee otherEmployee)
        {
            return Name == otherEmployee.Name && Designation == otherEmployee.Designation;
        }
        return false;
    }
}

class Program
{
    static void Main(string[] args)
    {
        List<Employee> list1 = new List<Employee>
        {
            new Employee("John", "Manager"),
            new Employee("Alice", "Developer"),
            new Employee("Bob", "Designer")
        };

        List<Employee> list2 = new List<Employee>
        {
            new Employee("Alice", "Developer"), // Duplicate
            new Employee("Eve", "Manager"),
            new Employee("Charlie", "Tester")
        };

        HashSet<Employee> mergedList = new HashSet<Employee>(list1.Concat(list2));

        Console.WriteLine("Merged Employee List:");
        foreach (var employee in mergedList)
        {
            Console.WriteLine($"Name: {employee.Name}, Designation: {employee.Designation}");
        }
    }
}







using System;
using System.Collections.Generic;

// Define an Employee class
class Employee
{
    public string Name { get; set; }
    public string Designation { get; set; }

    public Employee(string name, string designation)
    {
        Name = name;
        Designation = designation;
    }
}

// Define a DesignationLists class to hold lists of employees for each designation
class DesignationLists
{
    public List<Employee> ProgramManagers { get; } = new List<Employee>();
    public List<Employee> ProjectManagers { get; } = new List<Employee>();
    public List<Employee> TeamLeads { get; } = new List<Employee>();
    public List<Employee> SeniorProgrammers { get; } = new List<Employee>();
    public List<Employee> JuniorProgrammers { get; } = new List<Employee>();
}

class Program
{
    static void Main(string[] args)
    {
        DesignationLists d = new DesignationLists();

        while (true)
        {
            Console.WriteLine("Menu:\n1. Add Employee\n2. Display List\n3. Exit");
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    AddEmployee(d);
                    break;
                case 2:
                    Display(d);
                    break;
                case 3:
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please choose a valid option.");
                    break;
            }
        }
    }

    static void AddEmployee(DesignationLists d)
    {
        Console.WriteLine("Enter employee name: ");
        string name = Console.ReadLine();
        
        Console.WriteLine("Enter employee designation (e.g., 'PM', 'PrjM', 'TL', 'SP', 'JP'): ");
        string designation = Console.ReadLine();

        Employee employee = new Employee(name, designation);

        // Add the employee to the appropriate list based on designation
        switch (designation)
        {
            case "PM":
                d.ProgramManagers.Add(employee);
                break;
            case "PrjM":
                d.ProjectManagers.Add(employee);
                break;
            case "TL":
                d.TeamLeads.Add(employee);
                break;
            case "SP":
                d.SeniorProgrammers.Add(employee);
                break;
            case "JP":
                d.JuniorProgrammers.Add(employee);
                break;
            default:
                Console.WriteLine("Invalid designation. Employee not added.");
                break;
        }
    }

    static void Display(DesignationLists d)
    {
        Console.WriteLine("\nEmployee List:");
        DisplayEmployees("Program Managers", d.ProgramManagers);
        DisplayEmployees("Project Managers", d.ProjectManagers);
        DisplayEmployees("Team Leads", d.TeamLeads);
        DisplayEmployees("Senior Programmers", d.SeniorProgrammers);
        DisplayEmployees("Junior Programmers", d.JuniorProgrammers);
    }

    static void DisplayEmployees(string title, List<Employee> employees)
    {
        Console.WriteLine($"--- {title} ---");
        foreach (var employee in employees)
        {
            Console.WriteLine($"Name: {employee.Name}, Designation: {employee.Designation}");
        }
    }
}






using System;

public class MinMaxFinder<T> where T : IComparable<T>
{
    private T[] elements;

    public MinMaxFinder(T element1, T element2, T element3)
    {
        elements = new T[] { element1, element2, element3 };
    }

    public T FindMin()
    {
        T min = elements[0];
        foreach (T element in elements)
        {
            if (element.CompareTo(min) < 0)
            {
                min = element;
            }
        }
        return min;
    }

    public T FindMax()
    {
        T max = elements[0];
        foreach (T element in elements)
        {
            if (element.CompareTo(max) > 0)
            {
                max = element;
            }
        }
        return max;
    }
}





class Program
{
    static void Main()
    {
        MinMaxFinder<int> intMinMaxFinder = new MinMaxFinder<int>(10, 5, 15);
        int minInt = intMinMaxFinder.FindMin();
        int maxInt = intMinMaxFinder.FindMax();

        MinMaxFinder<double> doubleMinMaxFinder = new MinMaxFinder<double>(3.14, 1.0, 2.71);
        double minDouble = doubleMinMaxFinder.FindMin();
        double maxDouble = doubleMinMaxFinder.FindMax();

        Console.WriteLine($"Min Int: {minInt}, Max Int: {maxInt}");
        Console.WriteLine($"Min Double: {minDouble}, Max Double: {maxDouble}");
    }
}








//using System;
//using System.Collections;

//namespace Prj1Day19Col
//{

//    class Program
//    {
//        static void Main(string[] args)
//        {
//            BitArray myBitArr1 = new BitArray(4);
//            BitArray myBitArr2 = new BitArray(4);
//            myBitArr1[0] = false;
//            myBitArr1[1] = false;
//            myBitArr1[2] = true;
//            myBitArr1[3] = true;
//            myBitArr2[0] = false;
//            myBitArr2[2] = false;
//            myBitArr2[1] = true;
//            myBitArr2[3] = true;
//            PrintValues("\n\nBA1 : ", myBitArr1);
//            PrintValues("\n\nBA2 : ", myBitArr2);
//            PrintValues("\n\nOr : BA1.Or(BA2) : ", myBitArr1.Or(myBitArr2));
//            Console.WriteLine("\n");
//        }
//        public static void PrintValues(string s, IEnumerable myList)
//        {
//            Console.WriteLine(s);
//            foreach (Object obj in myList)
//            {
//                Console.Write(obj + "\t");
//            }
//        }
//    }
//}


Ask the user 4 (true/false) questions and compare the answers that user enters with the actual answers

to calculate the marks. Use BitArray to store user's and actual answers.

Q1: Collection namespace has ICollection

interface(T/F):

Q2: An IList in C# represents the class List in other

Languages(T/F): Q3: An Array and any collection is interchangeable

object Types (T/F): Q4: Collection is a part of BCL in .Net Framework

(T/F):

BitArray actual-new BitArray(4).

actual[0]=true, actual[1] = fa BitArray actual new BitArray(4);

actual[0]= true; actual[1]= false; actual[2] = true;








Implement a railway ticket counter scenario where there are two queues- one general and one for senior citizen.
Tickets are issued such that for every one person in senior citizen queue, two persons in general queue are processed.
Write a program that takes input for 10 people who come at various points and print the list of people in the order of their processing sequence.
Person : Name, age : Input
Eg: Person1, Person4, Person5, Person6 -> SQ ; Remaining Person ->GQ
Start Processing
Process both queues completely
Take care of all the elements in both the queues being dequed.
If any queue is bigger, first take the approach, once one queue is emptied, dequeue the second queue without wait.








using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Queue<Person> generalQueue = new Queue<Person>();
        Queue<Person> seniorCitizenQueue = new Queue<Person>();

        for (int i = 1; i <= 10; i++)
        {
            Console.Write($"Enter the name of Person {i}: ");
            string name = Console.ReadLine();
            Console.Write($"Enter the age of Person {i}: ");
            int age = int.Parse(Console.ReadLine());

            Person person = new Person(name, age);

            if (age >= 60)
            {
                seniorCitizenQueue.Enqueue(person);
                Console.WriteLine($"{name} added to the Senior Citizen Queue.");
            }
            else
            {
                generalQueue.Enqueue(person);
                Console.WriteLine($"{name} added to the General Queue.");
            }
        }

        Console.WriteLine("\nProcessing Ticket Counter Queue:");

        while (seniorCitizenQueue.Count > 0)
        {
            Console.WriteLine($"Processing {seniorCitizenQueue.Dequeue()}");
            if (generalQueue.Count >= 2)
            {
                Console.WriteLine($"Processing {generalQueue.Dequeue()}");
                Console.WriteLine($"Processing {generalQueue.Dequeue()}");
            }
            else if (generalQueue.Count == 1)
            {
                Console.WriteLine($"Processing {generalQueue.Dequeue()}");
                Console.WriteLine("No more people in the General Queue.");
            }
        }

        while (generalQueue.Count > 0)
        {
            Console.WriteLine($"Processing {generalQueue.Dequeue()}");
        }
    }
}

class Person
{
    public string Name { get; }
    public int Age { get; }

    public Person(string name, int age)
    {
        Name = name;
        Age = age;
    }

    public override string ToString()
    {
        return $"{Name} (Age: {Age})";
    }
}

using System;

public class MaxMinFinder<T> where T : IComparable<T>
{
    public T FindMax(T a, T b, T c)
    {
        T max = a;
        if (b.CompareTo(max) > 0)
        {
            max = b;
        }
        if (c.CompareTo(max) > 0)
        {
            max = c;
        }
        return max;
    }

    public T FindMin(T a, T b, T c)
    {
        T min = a;
        if (b.CompareTo(min) < 0)
        {
            min = b;
        }
        if (c.CompareTo(min) < 0)
        {
            min = c;
        }
        return min;
    }
}
MaxMinFinder<double> doubleFinder = new MaxMinFinder<double>();
double a = 5.7;
double b = 3.2;
double c = 7.1;

double max = doubleFinder.FindMax(a, b, c);
double min = doubleFinder.FindMin(a, b, c);

Console.WriteLine($"Max: {max}");
Console.WriteLine($"Min: {min}");


