using System;
using System.Collections.Generic;
namespace Capstone_2_Task_List
{
    public class Task
    {
        // Making List
        // Populating List with Data
        private static List<Task> _tasks = new List<Task>
        {
            new Task("Jack", "Does the work", DateTime.Parse("10/25/2019")),
            new Task("Tristan", "Stares blankly", DateTime.Parse("10/24/2019")),
            new Task("Steve", "Does nothing", DateTime.Parse("10/25/2019"))
        };


        #region fields
        private string _name;
        private string _description;
        private DateTime _dueDate;
        private bool _complete;
        #endregion

        #region properties
        public string Name { get { return _name; } set { _name = value; } }
        public string Description { get { return _description; } set { _description = value; } }
        public DateTime DueDate { get { return _dueDate; } set { _dueDate = value; } }
        public bool Complete { get { return _complete; } set { _complete = value; } }
        #endregion

        #region constructors
        public Task() { }

        public Task(string name, string description, DateTime dueDate, bool complete = false)
        {
            _name = name;
            _description = description;
            _dueDate = dueDate;
            _complete = complete;
        }
        #endregion

        #region methods
        // This method displays all tasks
        public static void DisplayTasks()
        {
            for (int i = 0; i < _tasks.Count; i++)
            {
                Console.WriteLine($"{i+1}." +
                                  $"\t{_tasks[i].Name}\n" +
                                  $"\t{_tasks[i].DueDate.ToShortDateString()}\n" +
                                  $"\t{_tasks[i].Complete}\n" +
                                  $"\t{_tasks[i].Description}\n");
            }
            Console.WriteLine();
        }

        // This method displays only tasks with a certain member in it
        public static void DisplayTasksMember(string member)
        {
            // This foreach loop goes through _tasks and determines whether it has a "member" in it
            foreach (Task task in _tasks)
            {
                if (task.Name == member)
                {
                    Console.WriteLine($"\t{task.Name}\n" +
                                      $"\t{task.DueDate.ToShortDateString()}\n" +
                                      $"\t{task.Complete}\n" +
                                      $"\t{task.Description}\n");
                }
            }
            Console.WriteLine();
        }

        // This method displays tasks before a certain date
        public static void DisplayTasksDate(DateTime date)
        {
            // This foreach loop goes through _tasks and determines if a selected task is before the "date"
            foreach (Task task in _tasks)
            {
                if (task.DueDate < date)
                {
                    Console.WriteLine($"\t{task.Name}\n" +
                                      $"\t{task.DueDate.ToShortDateString()}\n" +
                                      $"\t{task.Complete}\n" +
                                      $"\t{task.Description}\n");
                }
            }
            Console.WriteLine();
        }

        // This method allows users to edit tasks
        public static void EditTask(int taskNum, int taskField)
        {
            taskNum--;
            bool tryBool;

            // This switch statement is for determining which field to edit
            switch (taskField)
            {
                case 1:
                    Console.Write("Please input a name for this task: ");
                    _tasks[taskNum].Name = Console.ReadLine();
                    break;
                case 2:
                    Console.Write("Please input a description for this task: ");
                    _tasks[taskNum].Description = Console.ReadLine();
                    break;
                    // Case 3 and 4 both have a verification if statement to make sure that the user has put in the correct info
                case 3:
                    Console.Write("Please input an end date for this task: ");
                    DateTime date;
                    tryBool = DateTime.TryParse(Console.ReadLine(), out date);
                    if (tryBool)
                    {
                        _tasks[taskNum].DueDate = date;
                    }
                    else
                    {
                        Console.WriteLine("Please enter a valid date.");
                        EditTask(taskNum, taskField);
                    }
                    break;
                case 4:
                    Console.Write("Please input a completion for this task: ");
                    bool field;
                    tryBool = bool.TryParse(Console.ReadLine(), out field);
                    if (tryBool)
                    {
                        _tasks[taskNum].Complete = field;
                    }
                    else
                    {
                        Console.WriteLine("Please enter a valid boolean.");
                        EditTask(taskNum, taskField);
                    }
                    break;
                default:
                    break;
            }
        }

        // This method is for adding tasks to the _tasks list
        public static void AddTask(Task task)
        {
            _tasks.Add(task);
        }

        // This method is for removing tasks from the _tasks list
        public static void DeleteTask(int taskNum)
        {
            taskNum--;
            // Display the task for the user before we delete it
            Console.WriteLine($"{taskNum + 1}." +
                              $"\t{_tasks[taskNum].Name}\n" +
                              $"\t{_tasks[taskNum].DueDate.ToShortDateString()}\n" +
                              $"\t{_tasks[taskNum].Complete}\n" +
                              $"\t{_tasks[taskNum].Description}");

            // Double checks with the user to remove the task
            bool check = GetCheck("Are you sure you want to remove this task? (y/n)");
            if (check)
            {
                _tasks.RemoveAt(taskNum);
            }
        }

        // This method is for completing tasks on the _tasks list
        public static void CompleteTask(int taskNum)
        {
            taskNum--;
            // Display the task for the user before we complete it
            Console.WriteLine($"{taskNum + 1}." +
                  $"\t{_tasks[taskNum].Name}\n" +
                  $"\t{_tasks[taskNum].DueDate.ToShortDateString()}\n" +
                  $"\t{_tasks[taskNum].Complete}\n" +
                  $"\t{_tasks[taskNum].Description}");

            // Double checks with the user to complete the task
            bool check = GetCheck("Are you sure you want to complete this task? (y/n)");
            if (check)
            {
                _tasks[taskNum].Complete = true;
            }
        }

        // This method is for confirming user input
        public static bool GetCheck(string message)
        {
            Console.WriteLine(message);

            string check = Console.ReadLine().ToLower();

            if (check == "y")
            {
                return true;
            }
            else if (check == "n")
            {
                return false;
            }
            else
            {
                return GetCheck(message);
            }

        }

        // This method lists the amount of tasks in the list
        public static int ListCount()
        {
            return _tasks.Count;
        }

        #endregion
    }
}
