namespace SimpleNote.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateNoteTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Notes", "UserId", c => c.Int(nullable: false));
            CreateIndex("dbo.Notes", "UserId");
            AddForeignKey("dbo.Notes", "UserId", "dbo.Users", "Id", cascadeDelete: true);
            DropColumn("dbo.Notes", "Title");
            DropColumn("dbo.Notes", "Author");
            DropColumn("dbo.Notes", "AddedDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Notes", "AddedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Notes", "Author", c => c.String());
            AddColumn("dbo.Notes", "Title", c => c.String());
            DropForeignKey("dbo.Notes", "UserId", "dbo.Users");
            DropIndex("dbo.Notes", new[] { "UserId" });
            DropColumn("dbo.Notes", "UserId");
        }
    }
}
