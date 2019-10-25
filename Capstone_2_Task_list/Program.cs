using System;

namespace Capstone_2_Task_List
{
    class Program
    {
        static void Main(string[] args)
        {
            // bool that determines when the program is finished
            bool tasksUnfinished = true;
            while (tasksUnfinished)
            {
                // Displays options for the user
                PrintOptions();
                string userInput = GetUserInput("Please enter one of the above options: ");

                // Switch statement for picking an option
                switch (userInput)
                {
                    case "1":
                        Task.DisplayTasks();
                        break;
                    case "2":
                        DisplayTasksMember();
                        break;
                    case "3":
                        DisplayTasksDate();
                        break;
                    case "4":
                        EditTask();
                        break;
                    case "5":
                        AddTask();
                        break;
                    case "6":
                        RemoveTask();
                        break;
                    case "7":
                        CompleteTask();
                        break;
                    case "8":
                        tasksUnfinished = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid number. \n");
                        break;
                }
            }

        }

        // This method prints the options
        public static void PrintOptions()
        {
            Console.WriteLine("1. List tasks");
            Console.WriteLine("2. List tasks for a member");
            Console.WriteLine("3. List tasks before a date");
            Console.WriteLine("4. Edit task");
            Console.WriteLine("5. Add task");
            Console.WriteLine("6. Delete task");
            Console.WriteLine("7. Mark task complete");
            Console.WriteLine("8. Quit");
            Console.WriteLine();
        }

        // This method is for grabbing user input
        public static string GetUserInput(string message)
        {
            Console.Write(message);
            return Console.ReadLine();
        }

        // This method is for determing whether the user input is an integer and is within range
        public static int ParseRange(string message, int max)
        {
            // try catch to catch non-integers
            try
            {
                int number = int.Parse(GetUserInput(message));

                // if statement to determine if the integer is in range
                if (number > 0 && number <= max)
                {
                    return number;
                }
                else
                {
                    Console.WriteLine("\nPlease enter a number within range.");
                    return ParseRange(message, max);
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("\nPlease enter a valid number.");
                return ParseRange(message, max);
            }
        }


        // This method is for adding tasks
        public static void AddTask()
        {
            Task userTask = new Task();
            userTask.Name = GetUserInput("Please enter a name for the task: ");
            userTask.Description = GetUserInput("Please enter a description: ");
            userTask.DueDate =  DateTime.Parse(GetUserInput("Please enter an end date for task: "));
            Task.AddTask(userTask);
        }

        // This method is for removing tasks
        public static void RemoveTask()
        {
            Console.WriteLine("\nAvailable Tasks.");
            Task.DisplayTasks();
            Task.DeleteTask(ParseRange("Please enter a task to be deleted: ", Task.ListCount()));
        }

        //  This method is for completing tasks
        public static void CompleteTask()
        {
            Console.WriteLine("\nAvailable Tasks.");
            Task.DisplayTasks();
            Task.CompleteTask(ParseRange("Please enter a task to be completed: ", Task.ListCount()));
        }

        // This method displays tasks with a member in it
        public static void DisplayTasksMember()
        {
            Task.DisplayTasksMember(GetUserInput("Please enter a member name: "));
        }

        // This method displays tasks with a date before the time listed
        public static void DisplayTasksDate()
        {
            DateTime date = DateTime.Now;

            // This method determines whether a user input is a DateTime
            try
            {
                date = DateTime.Parse(GetUserInput("Please enter a date you wish to see all tasks before from: "));
            }
            catch (FormatException)
            {
                Console.WriteLine("\nPlease enter a valid date.");
            }
            Task.DisplayTasksDate(date);
        }

        // This method is for editing tasks
        public static void EditTask()
        {
            Console.WriteLine("\nAvailable Tasks.");
            Task.DisplayTasks();
            int taskNum = ParseRange("Please enter a task number: ", Task.ListCount());
            int taskField = ParseRange("Please enter a field number (1-4): ", 4);
            Task.EditTask(taskNum, taskField);
        }
    }
}
