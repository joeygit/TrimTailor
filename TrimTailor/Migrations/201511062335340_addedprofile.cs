namespace TrimTailor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedprofile : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Profiles",
                c => new
                    {
                        TrimUserId = c.String(nullable: false, maxLength: 128),
                        created_at = c.DateTime(nullable: false),
                        updated_at = c.DateTime(nullable: false),
                        mes_waist = c.Decimal(nullable: false, precision: 18, scale: 2),
                        mes_stomach = c.Decimal(nullable: false, precision: 18, scale: 2),
                        mes_shoulders = c.Decimal(nullable: false, precision: 18, scale: 2),
                        mes_neck = c.Decimal(nullable: false, precision: 18, scale: 2),
                        mes_chest = c.Decimal(nullable: false, precision: 18, scale: 2),
                        mes_torso = c.Decimal(nullable: false, precision: 18, scale: 2),
                        mes_inseam = c.Decimal(nullable: false, precision: 18, scale: 2),
                        mes_rightarm = c.Decimal(nullable: false, precision: 18, scale: 2),
                        mes_leftarm = c.Decimal(nullable: false, precision: 18, scale: 2),
                        mes_necktoshoulder = c.Decimal(nullable: false, precision: 18, scale: 2),
                        mes_heightft = c.Decimal(nullable: false, precision: 18, scale: 2),
                        mes_heightin = c.Decimal(nullable: false, precision: 18, scale: 2),
                        mes_weight = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.TrimUserId)
                .ForeignKey("dbo.AspNetUsers", t => t.TrimUserId)
                .Index(t => t.TrimUserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Profiles", "TrimUserId", "dbo.AspNetUsers");
            DropIndex("dbo.Profiles", new[] { "TrimUserId" });
            DropTable("dbo.Profiles");
        }
    }
}
