namespace CustomerPayments.DataModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customers", "FirstName", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Customers", "LastName", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Transactions", "Discription", c => c.String(nullable: false, maxLength: 200));
            AlterColumn("dbo.Transactions", "BeneficiaryAccount", c => c.String(nullable: false, maxLength: 30));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Transactions", "BeneficiaryAccount", c => c.String(maxLength: 30));
            AlterColumn("dbo.Transactions", "Discription", c => c.String(maxLength: 200));
            AlterColumn("dbo.Customers", "LastName", c => c.String(maxLength: 50));
            AlterColumn("dbo.Customers", "FirstName", c => c.String(maxLength: 50));
        }
    }
}
