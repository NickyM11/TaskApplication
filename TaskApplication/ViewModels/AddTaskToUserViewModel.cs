using System;
using System.Collections.Generic;
using TaskApplication.Models;

namespace TaskApplication.ViewModels
{
    public class AddTaskToUserViewModel
    {
        //User to assign tasks to
        public User User { get; set; }

        //Task to assign to user
        public List<Task> Tasks { get; set; }

        public DateTime Deadline { get; set; }
    }
}