namespace TaskApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeleteTestModel : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.Tests");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Tests",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        tekst = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
        }
    }
}
