namespace VisitorsApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Visitors",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        CertificateNumber = c.Int(nullable: false),
                        EnterTime = c.DateTime(nullable: false),
                        ExitTime = c.DateTime(nullable: false),
                        VisitPurpose = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Visitors");
        }
    }
}
