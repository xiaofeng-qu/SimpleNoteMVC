namespace SimpleNote.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddForgotPasswordTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Forgotpasswords",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        Activation = c.String(maxLength: 32),
                        Time = c.DateTime(nullable: false),
                        Status = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Forgotpasswords", "UserId", "dbo.Users");
            DropIndex("dbo.Forgotpasswords", new[] { "UserId" });
            DropTable("dbo.Forgotpasswords");
        }
    }
}
