using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskApplication.Models
{
    [Table("UserTask")]
    public class UserTask
    {
        [Key, Column(Order = 0)]
        [ForeignKey("User")]
        public int UserId { get; set; }

        [Key, Column(Order = 1)]
        [ForeignKey("Task")]
        public int TaskId { get; set; }

        [Required]
        public DateTime Deadline { get; set; }

        public User User { get; set; }
        public Task Task { get; set; }
    }
}