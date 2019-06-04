namespace Benedicta.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedProperty : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Abouts", "Text", c => c.String(storeType: "ntext"));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Abouts", "Text");
        }
    }
}
