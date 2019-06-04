namespace Benedicta.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateDatabase : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Welcomes", "Photo", c => c.String(maxLength: 250));
            DropColumn("dbo.Welcomes", "Phone");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Welcomes", "Phone", c => c.String(maxLength: 50));
            DropColumn("dbo.Welcomes", "Photo");
        }
    }
}
