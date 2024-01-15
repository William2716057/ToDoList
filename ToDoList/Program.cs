using System.Runtime.Intrinsics.X86;
using System;
using System.Collections.Generic;
//task class to represent name and completed properties
class Task
{
    public string TaskName { get; set; }
    public bool IsCompleted { get; set; }
}



class ToDoList
{
    private List<Task> tasks;
    //constructor to initialise Task property of ToDoList
    public ToDoList()
    {
        tasks = new List<Task>();
    }
    //give name and add it to list of tasks
    public void AddTask(string taskName)
    {
        Task newTask = new Task { TaskName = taskName, IsCompleted = false };
        tasks.Add(newTask);
    }
    //displays by iterating through each task and displaying it's current state
    public void DisplayTasks()
    {
        Console.WriteLine("To-Do List:");
        foreach (var task in tasks)
        {
            string status = task.IsCompleted ? "[Completed]" : "[Pending]";
            Console.WriteLine($"{status} {task.TaskName}");
        }
    }

    public void MarkTaskAsCompleted(int taskIndex)
    {
        if (taskIndex >= 0 && taskIndex < tasks.Count)
        {
            tasks[taskIndex].IsCompleted = true;
            Console.WriteLine("Task marked as completed.");
        }
        else
        {
            Console.WriteLine("Invalid task index.");
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        ToDoList toDoList = new ToDoList();
        //display the options
        while (true)
        {
            Console.WriteLine("\nMenu:");
            Console.WriteLine("1. Add Task");
            Console.WriteLine("2. Display Tasks");
            Console.WriteLine("3. Mark Task as Completed");
            Console.WriteLine("4. Exit");

            Console.Write("Enter your choice (1-4): ");
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.Write("Enter task name: ");
                    string taskName = Console.ReadLine();
                    toDoList.AddTask(taskName);
                    break;

                case 2:
                    toDoList.DisplayTasks();
                    break;

                case 3:
                    Console.Write("Enter the index of the task to mark as completed: ");
                    int taskIndex = int.Parse(Console.ReadLine());
                    toDoList.MarkTaskAsCompleted(taskIndex);
                    break;

                case 4:
                    Environment.Exit(0);
                    break;

                default:
                    Console.WriteLine("Invalid choice. Please enter a number between 1 and 4.");
                    break;
            }
        }
    }
}

