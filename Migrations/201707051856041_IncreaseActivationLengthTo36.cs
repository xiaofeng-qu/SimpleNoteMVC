namespace SimpleNote.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IncreaseActivationLengthTo36 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Forgotpasswords", "Activation", c => c.String(maxLength: 36));
            AlterColumn("dbo.Users", "Activation", c => c.String(maxLength: 36));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "Activation", c => c.String(maxLength: 32));
            AlterColumn("dbo.Forgotpasswords", "Activation", c => c.String(maxLength: 32));
        }
    }
}
