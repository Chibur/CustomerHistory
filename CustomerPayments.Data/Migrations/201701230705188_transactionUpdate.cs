namespace CustomerPayments.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class transactionUpdate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Accounts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AccountNumber = c.String(nullable: false, maxLength: 30),
                        Balance = c.Decimal(nullable: false, storeType: "money"),
                        AccountType = c.Int(nullable: false),
                        CustomerId = c.Int(),
                        DateCreated = c.DateTime(nullable: false),
                        DateModified = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.CustomerId)
                .Index(t => t.CustomerId);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 50),
                        LastName = c.String(nullable: false, maxLength: 50),
                        PhoneNumber = c.String(maxLength: 20),
                        EmailAddress = c.String(maxLength: 50),
                        Birthdate = c.DateTime(nullable: false, storeType: "date"),
                        DateCreated = c.DateTime(nullable: false),
                        DateModified = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Transactions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Amount = c.Decimal(nullable: false, storeType: "money"),
                        Discription = c.String(nullable: false, maxLength: 200),
                        BeneficiaryAccount = c.String(nullable: false, maxLength: 30),
                        SenderAccount = c.String(nullable: false, maxLength: 30),
                        AccountId = c.Int(),
                        CustomerId = c.Int(),
                        DateCreated = c.DateTime(nullable: false),
                        DateModified = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Accounts", t => t.AccountId)
                .ForeignKey("dbo.Customers", t => t.CustomerId)
                .Index(t => t.AccountId)
                .Index(t => t.CustomerId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Transactions", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.Transactions", "AccountId", "dbo.Accounts");
            DropForeignKey("dbo.Accounts", "CustomerId", "dbo.Customers");
            DropIndex("dbo.Transactions", new[] { "CustomerId" });
            DropIndex("dbo.Transactions", new[] { "AccountId" });
            DropIndex("dbo.Accounts", new[] { "CustomerId" });
            DropTable("dbo.Transactions");
            DropTable("dbo.Customers");
            DropTable("dbo.Accounts");
        }
    }
}
