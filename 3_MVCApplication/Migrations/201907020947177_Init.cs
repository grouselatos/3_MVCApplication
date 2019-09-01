namespace _3_MVCApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    //everytime a migration is added in console, a file is created
    //pote den allazeis to arxeio tou migration! an thes na kaneis kati allo, prepei na svhseis to arxeio kai na ftiakseis allo
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Movies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Year = c.Int(nullable: false),
                        Watched = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Movies");
        }
    }
}
