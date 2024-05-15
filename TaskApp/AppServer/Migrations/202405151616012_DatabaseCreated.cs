namespace AppServer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DatabaseCreated : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MyTasks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        About = c.String(),
                        Status = c.String(),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Login = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MyTasks", "UserId", "dbo.Users");
            DropIndex("dbo.MyTasks", new[] { "UserId" });
            DropTable("dbo.Users");
            DropTable("dbo.MyTasks");
        }
    }
}
