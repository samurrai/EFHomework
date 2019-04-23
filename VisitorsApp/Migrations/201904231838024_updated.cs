namespace VisitorsApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updated : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Visitors", "EnterTime", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Visitors", "EnterTime", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
        }
    }
}
