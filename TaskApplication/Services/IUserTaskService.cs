using System;

namespace TaskApplication.Services
{
    public interface IUserTaskService
    {
        bool AddTaskToUser(int taskId, int userId, DateTime deadline, out string errorMessage);
    }
}
