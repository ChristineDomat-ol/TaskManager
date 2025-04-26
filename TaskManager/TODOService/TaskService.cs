using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TODOCommon;
using TODODataService;

namespace TODOService
{
    public class TaskService
    {
        TaskDataService taskDataService = new TaskDataService();

        public TaskService()
        {
            taskDataService = new TaskDataService();
        }
        public List<TODOCommon.Task> GetAllTasks()
        {
            return taskDataService.GetTasks();
        }

        public List<TODOCommon.Task> GetAllTasksByStatus(string status)
        {
            List<TODOCommon.Task> tasks = GetAllTasks();
            List<TODOCommon.Task> tasksByStatus = new List<TODOCommon.Task>();

            foreach (var task in tasks)
            {
                if (task.Status == status)
                {
                    tasksByStatus.Add(task);
                }
            }

            return tasksByStatus;
        }

        public void UpdateTaskStatus(int id, string newStatus)
        {
            List<TODOCommon.Task> tasks = GetAllTasks();

            foreach (var task in tasks)
            {
                if (task.TaskId == id)
                {
                    taskDataService.UpdateTask(id, task.Description, newStatus);
                }

            }
        }

        public void UpdateTaskDescription(int id, string newDescription)
        {
            List<TODOCommon.Task> tasks = GetAllTasks();

            foreach (var task in tasks)
            {
                if (task.TaskId == id)
                {
                    taskDataService.UpdateTask(id, newDescription, task.Status);
                }

            }
        }

        public void DeleteTask(int id)
        {
            taskDataService.DeleteTask(id);
        }

        //public void CreateTask(string description, string status)
        //{
        //    List<TODOCommon.Task> tasks = GetAllTasks();
        //    int taskIdCounter = 0;

        //    foreach (var task in tasks)
        //    {
        //        if (task.TaskId > taskIdCounter)
        //        {
        //            taskIdCounter = task.TaskId;
        //        }
        //    }

        //    taskIdCounter++;
        //    TODOCommon.Task newTask = new TODOCommon.Task
        //    {
        //        TaskId = taskIdCounter,
        //        Description = description,
        //        CreationDate = DateTime.Now,
        //        ModifiedDate = DateTime.Now,
        //        Status = status
        //    };

        //    taskDataService.CreateTask(newTask);
        //}
    }
}
