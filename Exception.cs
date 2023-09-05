using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            if (args.Length == 0)
            {
                Console.WriteLine("Please provide a comma-separated list of topic name and time in hours.");
                return;
            }

            string input = string.Join(" ", args);
            string[] topicTimePairs = input.Split(',');

            Dictionary<string, int> topicTimes = new Dictionary<string, int>();

            foreach (var pair in topicTimePairs)
            {
                string[] parts = pair.Trim().Split(' ');
                if (parts.Length == 2)
                {
                    string topic = parts[0];
                    if (int.TryParse(parts[1], out int timeInHours))
                    {
                        topicTimes[topic] = timeInHours;
                    }
                    else
                    {
                        Console.WriteLine($"Invalid time format for topic: {topic}");
                    }
                }
                else
                {
                    Console.WriteLine($"Invalid input format: {pair}");
                }
            }

            int totalHours = 0;
            int hoursPerDay = 8;
            int currentDay = 1;

            Console.WriteLine("Topics covered day-wise:");
            foreach (var pair in topicTimes)
            {
                if (totalHours + pair.Value <= hoursPerDay)
                {
                    Console.WriteLine($"Day {currentDay}: {pair.Key} ({pair.Value} hours)");
                    totalHours += pair.Value;
                }
                else
                {
                    currentDay++;
                    totalHours = 0;
                    Console.WriteLine($"Day {currentDay}: {pair.Key} ({pair.Value} hours)");
                    totalHours += pair.Value;
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }
}
