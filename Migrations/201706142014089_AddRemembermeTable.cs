namespace SimpleNote.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRemembermeTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Remembermes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        AuthentificatorOne = c.String(maxLength: 20),
                        AuthentificatorTwo = c.String(maxLength: 64),
                        Expires = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Remembermes", "UserId", "dbo.Users");
            DropIndex("dbo.Remembermes", new[] { "UserId" });
            DropTable("dbo.Remembermes");
        }
    }
}
