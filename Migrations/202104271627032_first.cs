namespace TraineeResourceManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class first : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.logins",
                c => new
                    {
                        loginid = c.Int(nullable: false, identity: true),
                        username = c.String(nullable: false, maxLength: 20),
                        password = c.String(nullable: false, maxLength: 20),
                        job = c.String(nullable: false, maxLength: 20),
                    })
                .PrimaryKey(t => t.loginid);
            
            CreateTable(
                "dbo.requests",
                c => new
                    {
                        reqid = c.Int(nullable: false, identity: true),
                        reqname = c.String(nullable: false, maxLength: 20),
                        domain = c.String(nullable: false, maxLength: 20),
                        sdate = c.DateTime(nullable: false),
                        edate = c.DateTime(nullable: false),
                        pmid = c.Int(nullable: false),
                        tid = c.Int(nullable: false),
                        room = c.Int(nullable: false),
                        status = c.String(maxLength: 15),
                    })
                .PrimaryKey(t => t.reqid);
            
            CreateTable(
                "dbo.trainers",
                c => new
                    {
                        tid = c.Int(nullable: false, identity: true),
                        tname = c.String(nullable: false, maxLength: 20),
                        domain = c.String(nullable: false, maxLength: 20),
                    })
                .PrimaryKey(t => t.tid);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.trainers");
            DropTable("dbo.requests");
            DropTable("dbo.logins");
        }
    }
}
