using System;
using System.Collections.Generic;
using TaskApplication.DataAccessLayer;
using TaskApplication.Models;
using System.Linq;
using TaskApplication.ViewModels;

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

        public List<HomepageViewModel> GetTasksPerUser()
        {
            using (var db = new TaskDbContext())
            {
                var usersForView = new List<HomepageViewModel>();

                //Get users who have one or more tasks
                var userWithTasks = db.UserTasks.Select(ut => ut.UserId).Distinct();
                foreach (int userId in userWithTasks)
                {
                    User user = db.Users.Find(userId);
                    
                    HomepageViewModel homepageViewModel = new HomepageViewModel()
                    {
                        User = user,
                        Tasks = db.UserTasks.Include("Task").Where(u => u.UserId == user.UserId).ToList()
                    };
                    usersForView.Add(homepageViewModel);
                }
                return usersForView;
            }
        }
    }
}