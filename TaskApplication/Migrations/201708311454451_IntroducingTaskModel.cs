namespace TaskApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IntroducingTaskModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Task",
                c => new
                    {
                        TaskId = c.Int(nullable: false, identity: true),
                        Description = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.TaskId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Task");
        }
    }
}
