namespace TrimTailor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class adding_address : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        created_at = c.DateTime(nullable: false),
                        updated_at = c.DateTime(nullable: false),
                        city = c.String(),
                        state = c.String(),
                        street = c.String(),
                        zipcode = c.String(),
                        label = c.String(),
                        TrimUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.TrimUser_Id)
                .Index(t => t.TrimUser_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Addresses", "TrimUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Addresses", new[] { "TrimUser_Id" });
            DropTable("dbo.Addresses");
        }
    }
}
