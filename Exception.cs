using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            if (args.Length % 2 != 0)
            {
                throw new ArgumentException("The list is not complete");
            }

            Dictionary<string, int> topics = new Dictionary<string, int>();
            
            for (int i = 0; i < args.Length; i += 2)
            {
                string topicName = args[i];
                if (!int.TryParse(args[i + 1], out int hours))
                {
                    throw new ArgumentException("The list is incorrect");
                }
                topics.Add(topicName, hours);
            }

            int hoursPerDay = 8;

            foreach (var topic in topics)
            {
                int daysNeeded = (int)Math.Ceiling((double)topic.Value / hoursPerDay);
                Console.WriteLine($"{topic.Key}: {daysNeeded} days training");
            }
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
} 
