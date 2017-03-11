namespace TaxiteBus.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nom1 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.AspNetUsers", "numeroUtil");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "numeroUtil", c => c.Int(nullable: false));
        }
    }
}
