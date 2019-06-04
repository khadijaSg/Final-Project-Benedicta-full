namespace Benedicta.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeletedTable : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.Reservations");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Reservations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 200),
                        Email = c.String(maxLength: 200),
                        Phone = c.String(maxLength: 50),
                        Time = c.DateTimeOffset(nullable: false, precision: 7),
                        Date = c.DateTime(nullable: false, storeType: "date"),
                        Seats = c.Int(nullable: false),
                        SpecialRequests = c.String(storeType: "ntext"),
                    })
                .PrimaryKey(t => t.Id);
            
        }
    }
}
