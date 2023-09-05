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
