namespace CustomerPayments.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class acocuntId : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Transactions", name: "Account_Id", newName: "AccountId");
            RenameIndex(table: "dbo.Transactions", name: "IX_Account_Id", newName: "IX_AccountId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Transactions", name: "IX_AccountId", newName: "IX_Account_Id");
            RenameColumn(table: "dbo.Transactions", name: "AccountId", newName: "Account_Id");
        }
    }
}
