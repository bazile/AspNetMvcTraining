namespace MigrationsDemo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Added_ISBN : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Book", "ISBN", c => c.String(nullable: false, maxLength: 13));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Book", "ISBN");
        }
    }
}
