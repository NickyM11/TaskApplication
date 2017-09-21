using System;
using System.Collections.Generic;
using System.Linq;
using TaskApplication.Models;
using TaskApplication.ViewModels;

namespace TaskApplication.Services
{
    public interface IUserTaskService
    {
        bool AddTaskToUser(int taskId, int userId, DateTime deadline, out string errorMessage);
        List<HomepageViewModel> GetTasksPerUser();
    }
}
