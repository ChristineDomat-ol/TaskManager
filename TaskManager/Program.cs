using TODODataService;
using TODOService;

namespace TaskManager
{
    internal class Program
    {
        static TaskService taskService = new TaskService();

        static string[] Actions = new string[] {
            "[1] Display All Task",
            "[2] Display All Task In Progress," +
            "[3] Create a NEW task",
            "[4] Update a task",
            "[5] Delete a task"
        };
        static void Main(string[] args)
        {
            DisplayActions();
            string action = GetUserInput();

            switch (action)
            {
                case "1":
                    GetAllTasks();
                    break;
                case "2":
                    Console.Write("Enter Status: ");
                    string status = Console.ReadLine();
                    GetAllTasksByStatus(status);
                    break;
            }

        }

        public static void DisplayActions()
        {
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
                Console.WriteLine("Task ID: " + task.TaskId +  ", Description:" + task.Description + ", Status:" + task.Status);
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

    }
}

