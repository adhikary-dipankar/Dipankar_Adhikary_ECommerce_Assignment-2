using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            Console.WriteLine("Enter a comma-separated list of topic name and hours (e.g., Java 24, JEE 10, JME 12):");
            string input = Console.ReadLine();
            
            // Split the input string by commas
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
            int totalHours = 0;
            int day = 1;
            Console.WriteLine("Topics covered day-wise:");
            foreach (var topic in topics)
            {
                Console.WriteLine($"Day {day}: {topic.Key} ({topic.Value} hours)");
                totalHours += topic.Value;
                if (totalHours >= 8)
                {
                    totalHours = 0;
                    day++;
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }
}
