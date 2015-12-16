namespace TrimTailor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class adding_names : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "firstname", c => c.String());
            AddColumn("dbo.AspNetUsers", "lastname", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "lastname");
            DropColumn("dbo.AspNetUsers", "firstname");
        }
    }
}
