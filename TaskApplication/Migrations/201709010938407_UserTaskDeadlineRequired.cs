namespace TaskApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserTaskDeadlineRequired : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserTask",
                c => new
                    {
                        UserId = c.Int(nullable: false),
                        TaskId = c.Int(nullable: false),
                        Deadline = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserId, t.TaskId })
                .ForeignKey("dbo.Task", t => t.TaskId, cascadeDelete: true)
                .ForeignKey("dbo.User", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.TaskId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserTask", "UserId", "dbo.User");
            DropForeignKey("dbo.UserTask", "TaskId", "dbo.Task");
            DropIndex("dbo.UserTask", new[] { "TaskId" });
            DropIndex("dbo.UserTask", new[] { "UserId" });
            DropTable("dbo.UserTask");
            RenameTable(name: "dbo.UserTask1", newName: "UserTasks");
        }
    }
}
