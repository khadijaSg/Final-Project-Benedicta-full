namespace Benedicta.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedReserveTableBg : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ReserveTableBgs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Photo = c.String(maxLength: 350),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ReserveTableBgs");
        }
    }
}
