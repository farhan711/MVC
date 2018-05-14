namespace MovieMix.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class populateMembershipTypeName : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE MembershipTypes SET MembershipTypename = 'Pay as You Go' WHERE Id = 1");
            Sql("UPDATE MembershipTypes SET MembershipTypename = 'Monthly' WHERE Id = 2");
            Sql("UPDATE MembershipTypes SET MembershipTypename = 'Quarterly' WHERE Id = 3");
            Sql("UPDATE MembershipTypes SET MembershipTypename = 'Annual' WHERE Id = 4");
        }
        
        public override void Down()
        {
        }
    }
}
