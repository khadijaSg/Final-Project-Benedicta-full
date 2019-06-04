namespace Benedicta.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateDatabase1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Menus", "Photo", c => c.String(maxLength: 350));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Menus", "Photo");
        }
    }
}
