namespace TtopAcademy.API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddOtp : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Otps",
                c => new
                    {
                        OtpID = c.Int(nullable: false, identity: true),
                        OtpType = c.Int(nullable: false),
                        Email = c.String(),
                        Code = c.Int(nullable: false),
                        NumberOfResend = c.Int(nullable: false),
                        LastSentDateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.OtpID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Otps");
        }
    }
}
