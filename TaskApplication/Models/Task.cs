using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskApplication.Models
{
    [Table("Task")]
    public class Task
    {
        [Key]
        public int TaskId { get; set; }

        [Required(ErrorMessage = "Taakomschrijving is verplicht")]
        public string Description { get; set; }

        public ICollection<User> Users { get; set;}

        public Task()
        {
            this.Users = new HashSet<User>();
        }
    }
}