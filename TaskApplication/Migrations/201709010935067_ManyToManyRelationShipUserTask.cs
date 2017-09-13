namespace TaskApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ManyToManyRelationShipUserTask : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserTasks",
                c => new
                    {
                        User_UserId = c.Int(nullable: false),
                        Task_TaskId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.User_UserId, t.Task_TaskId })
                .ForeignKey("dbo.User", t => t.User_UserId, cascadeDelete: true)
                .ForeignKey("dbo.Task", t => t.Task_TaskId, cascadeDelete: true)
                .Index(t => t.User_UserId)
                .Index(t => t.Task_TaskId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserTasks", "Task_TaskId", "dbo.Task");
            DropForeignKey("dbo.UserTasks", "User_UserId", "dbo.User");
            DropIndex("dbo.UserTasks", new[] { "Task_TaskId" });
            DropIndex("dbo.UserTasks", new[] { "User_UserId" });
            DropTable("dbo.UserTasks");
        }
    }
}
