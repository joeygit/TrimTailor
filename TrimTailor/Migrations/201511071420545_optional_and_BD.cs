namespace TrimTailor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class optional_and_BD : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Profiles", "birthdate", c => c.DateTime());
            AlterColumn("dbo.Profiles", "mes_waist", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("dbo.Profiles", "mes_stomach", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("dbo.Profiles", "mes_shoulders", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("dbo.Profiles", "mes_neck", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("dbo.Profiles", "mes_chest", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("dbo.Profiles", "mes_torso", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("dbo.Profiles", "mes_inseam", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("dbo.Profiles", "mes_rightarm", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("dbo.Profiles", "mes_leftarm", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("dbo.Profiles", "mes_necktoshoulder", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("dbo.Profiles", "mes_heightft", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("dbo.Profiles", "mes_heightin", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("dbo.Profiles", "mes_weight", c => c.Decimal(precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Profiles", "mes_weight", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Profiles", "mes_heightin", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Profiles", "mes_heightft", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Profiles", "mes_necktoshoulder", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Profiles", "mes_leftarm", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Profiles", "mes_rightarm", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Profiles", "mes_inseam", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Profiles", "mes_torso", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Profiles", "mes_chest", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Profiles", "mes_neck", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Profiles", "mes_shoulders", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Profiles", "mes_stomach", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Profiles", "mes_waist", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropColumn("dbo.Profiles", "birthdate");
        }
    }
}
