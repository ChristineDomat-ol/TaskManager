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
                    DisplayAllTask();
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

        public static void DisplayAllTask()
        {
            foreach (var task in taskService.GetAllTasks())
            {
                Console.WriteLine(task);
            }
        }
    }
}

