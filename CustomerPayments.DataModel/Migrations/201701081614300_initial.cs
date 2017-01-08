namespace CustomerPayments.DataModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Accounts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AccountNumber = c.String(maxLength: 30),
                        DateCreated = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                        Balance = c.Decimal(nullable: false, storeType: "money"),
                        AccountType = c.Int(nullable: false),
                        CustomerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: true)
                .Index(t => t.CustomerId);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(maxLength: 50),
                        LastName = c.String(maxLength: 50),
                        PhoneNumber = c.String(maxLength: 20),
                        EmailAddress = c.String(maxLength: 50),
                        Birthdate = c.DateTime(nullable: false, storeType: "date"),
                        LastModified = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Transactions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateSubmitted = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                        Amount = c.Decimal(nullable: false, storeType: "money"),
                        Discription = c.String(maxLength: 200),
                        BeneficiaryAccount = c.String(maxLength: 30),
                        AccountId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Accounts", t => t.AccountId, cascadeDelete: true)
                .Index(t => t.AccountId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Transactions", "AccountId", "dbo.Accounts");
            DropForeignKey("dbo.Accounts", "CustomerId", "dbo.Customers");
            DropIndex("dbo.Transactions", new[] { "AccountId" });
            DropIndex("dbo.Accounts", new[] { "CustomerId" });
            DropTable("dbo.Transactions");
            DropTable("dbo.Customers");
            DropTable("dbo.Accounts");
        }
    }
}
