using System;
using TaskApplication.DataAccessLayer;
using TaskApplication.Models;

namespace TaskApplication.Services
{
    public class UserTaskService : IUserTaskService
    {
        public bool AddTaskToUser(int taskId, int userId, DateTime deadline, out string errorMessage)
        {
            using (var db = new TaskDbContext())
            {
                Task TaskFromDb = db.Tasks.Find(taskId);
                User UserFromDb = db.Users.Find(userId);

                if (TaskFromDb == null || UserFromDb == null)
                {
                    errorMessage = "Deze taak of gebruiker is niet helaas niet gevonden";
                    return false;
                }

                UserTask UserTask = new UserTask()
                {
                    User = UserFromDb,
                    Task = TaskFromDb,
                    UserId = UserFromDb.UserId,
                    TaskId = TaskFromDb.TaskId,
                    Deadline = deadline
                };

                db.UserTasks.Add(UserTask);

                try
                {
                    db.SaveChanges();
                    errorMessage = String.Empty;

                    return true;
                }
                catch (System.Data.Entity.Infrastructure.DbUpdateException e)
                {
                    errorMessage = "Deze gebruiker heeft deze taak al op zijn naam staan";
                    return false;
                }
            }
        }
    }
}