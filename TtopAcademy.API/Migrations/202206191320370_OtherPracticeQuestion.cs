namespace TtopAcademy.API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OtherPracticeQuestion : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.OtherPracticeQuestions",
                c => new
                    {
                        PracticeQuestionID = c.Int(nullable: false, identity: true),
                        VideoID = c.Int(nullable: false),
                        QuestionNumber = c.Int(nullable: false),
                        Question = c.String(),
                        OptionA = c.String(),
                        OptionB = c.String(),
                        OptionC = c.String(),
                        OptionD = c.String(),
                        CorrectOption = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PracticeQuestionID);
        }
        
        public override void Down()
        {
            DropTable("dbo.OtherPracticeQuestions");
        }
    }
}
