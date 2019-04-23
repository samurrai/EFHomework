namespace VisitorsApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updated2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Visitors", "EnterTime", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.Visitors", "ExitTime", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Visitors", "ExitTime", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Visitors", "EnterTime", c => c.DateTime(nullable: false));
        }
    }
}
