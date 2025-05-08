using System;
using System.Collections.Generic;
using System.Diagnostics;

class Program
{
    static List<(string task, TimeSpan duration)> tasks = new List<(string, TimeSpan)>();
    static Stopwatch stopwatch = new Stopwatch();

    static void Main()
    {
        Console.WriteLine("Welcome to FocusVault Task Manager");
        while (true)
        {
            Console.WriteLine("\nOptions:");
            Console.WriteLine("1. Start a Task Timer");
            Console.WriteLine("2. View Completed Tasks");
            Console.WriteLine("3. Exit");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    StartTaskTimer();
                    break;
                case "2":
                    ViewTasks();
                    break;
                case "3":
                    Console.WriteLine("Goodbye!");
                    return;
                default:
                    Console.WriteLine("Invalid option, try again.");
                    break;
            }
        }
    }

    static void StartTaskTimer()
    {
        Console.Write("Enter task name: ");
        string taskName = Console.ReadLine();
        
        Console.WriteLine("Task timer started. Press ENTER when done.");
        stopwatch.Restart();  // Start tracking time
        
        Console.ReadLine();  // Wait for user to finish the task
        
        stopwatch.Stop();
        TimeSpan elapsedTime = stopwatch.Elapsed;
        tasks.Add((taskName, elapsedTime));

        Console.WriteLine($"Task '{taskName}' completed in {elapsedTime.TotalSeconds:F2} seconds.");
    }

    static void ViewTasks()
    {
        Console.WriteLine("\nCompleted Tasks:");
        foreach (var task in tasks)
        {
            Console.WriteLine($"- {task.task}: {task.duration.TotalSeconds:F2} seconds");
        }
    }
}