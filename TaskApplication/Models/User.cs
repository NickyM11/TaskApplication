using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskApplication.Models
{
    [Table("User")]
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Required(ErrorMessage ="Naam is verplicht")]
        public string name { get; set; }

        public virtual ICollection<Task> Tasks { get; set; }

        public User()
        {
            this.Tasks = new HashSet<Task>();
        }
    }
}