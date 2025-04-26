using TODODataService;
using TODOService;

namespace TaskManager
{
    internal class Program
    {
        static TaskService taskService = new TaskService();

        static string[] Actions = new string[] {
            "[1] Display All Task",
            "[2] Display All Task In Progress",
            "[3] Create a NEW task",
            "[4] Update a task",
            "[5] Delete a task",
            "[6] Exit"
        };
        static void Main(string[] args)
        {
            DisplayActions();
            string action = GetUserInput();

            while (action != "6")
            {
                switch (action)
                {
                    case "1":
                        GetAllTasks();
                        break;
                    case "2":
                        string status = "In Progress";
                        GetAllTasksByStatus(status);
                        break;
                    case "3":
                        break;
                    case "4":
                        UpdateTask();
                        break;
                    case "5":
                        DeleteTask();
                        break;
                }
                DisplayActions();
                action = GetUserInput();
            }

        }

        public static void DisplayActions()
        {
            Console.WriteLine("---------------------");
            Console.WriteLine("ACTIONS: ");
            foreach (var action in Actions)
            {
                Console.WriteLine(action);
            }
        }

        public static string GetUserInput()
        {
            Console.Write("\nAction: ");
            string action = Console.ReadLine();
            return action;
        }

        public static List<TODOCommon.Task> GetAllTasks()
        {
            foreach (var task in taskService.GetAllTasks())
            {
                Console.WriteLine("Task ID: " + task.TaskId + ", Description:" + task.Description + ", Status:" + task.Status);
            }
            return taskService.GetAllTasks();
        }

        public static void GetAllTasksByStatus(string status)
        {
            foreach (var task in taskService.GetAllTasksByStatus(status))
            {
                Console.WriteLine("Task ID: " + task.TaskId + ", Description:" + task.Description + ", Status:" + task.Status);
            }
        }

        //public static void CreateTask()
        //{
        //    Console.Write("Enter Task Description: ");
        //    string description = Console.ReadLine();

        //    Console.Write("Enter Task Description: ");
        //    string status = Console.ReadLine();

        //    taskService.CreateTask(description, status);
        //}

        public static void DeleteTask()
        {
            Console.Write("Enter Task ID to delete: ");
            int taskId = int.Parse(Console.ReadLine());

            taskService.DeleteTask(taskId);
        }

        public static void UpdateTask()
        {
            Console.Write("Enter Task ID to update: ");
            int taskId = int.Parse(Console.ReadLine());

            Console.Write("Enter New Task Description: ");
            string description = Console.ReadLine();

            Console.Write("Enter New Task Status: ");
            string status = Console.ReadLine();

            taskService.UpdateTaskDescription(taskId, description);
            taskService.UpdateTaskStatus(taskId, status);

        }
    }
}

