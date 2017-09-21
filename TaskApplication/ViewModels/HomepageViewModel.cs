using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TaskApplication.Models;

namespace TaskApplication.ViewModels
{
    public class HomepageViewModel
    {
        public User User;
        public List<UserTask> Tasks;
    }
}