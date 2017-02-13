namespace CustomerPayments.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class errorHandling : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "LoginId", c => c.String(nullable: false, maxLength: 6, fixedLength: true, unicode: false));
            CreateIndex("dbo.Accounts", "AccountNumber", unique: true);
            CreateIndex("dbo.Customers", "LoginId", unique: true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.Customers", new[] { "LoginId" });
            DropIndex("dbo.Accounts", new[] { "AccountNumber" });
            DropColumn("dbo.Customers", "LoginId");
        }
    }
}
