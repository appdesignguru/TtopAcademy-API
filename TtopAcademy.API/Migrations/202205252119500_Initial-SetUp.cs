namespace TtopAcademy.API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialSetUp : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CategoryID = c.Int(nullable: false, identity: true),
                        Number = c.Int(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.CategoryID);
            
            CreateTable(
                "dbo.CategorySubjects",
                c => new
                    {
                        CategorySubjectID = c.Int(nullable: false, identity: true),
                        CategoryID = c.Int(nullable: false),
                        SubjectID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CategorySubjectID)
                .ForeignKey("dbo.Categories", t => t.CategoryID, cascadeDelete: true)
                .ForeignKey("dbo.Subjects", t => t.SubjectID, cascadeDelete: true)
                .Index(t => t.CategoryID)
                .Index(t => t.SubjectID);
            
            CreateTable(
                "dbo.Subjects",
                c => new
                    {
                        SubjectID = c.Int(nullable: false, identity: true),
                        Number = c.Int(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.SubjectID);
            
            CreateTable(
                "dbo.CategorySubjectTopics",
                c => new
                    {
                        CategorySubjectTopicID = c.Int(nullable: false, identity: true),
                        CategorySubjectID = c.Int(nullable: false),
                        TopicID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CategorySubjectTopicID)
                .ForeignKey("dbo.CategorySubjects", t => t.CategorySubjectID, cascadeDelete: true)
                .ForeignKey("dbo.Topics", t => t.TopicID, cascadeDelete: true)
                .Index(t => t.CategorySubjectID)
                .Index(t => t.TopicID);
            
            CreateTable(
                "dbo.Topics",
                c => new
                    {
                        TopicID = c.Int(nullable: false, identity: true),
                        Number = c.Int(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.TopicID);
            
            CreateTable(
                "dbo.CategorySubjectTopicVideos",
                c => new
                    {
                        CategorySubjectTopicVideoID = c.Int(nullable: false, identity: true),
                        CategorySubjectTopicID = c.Int(nullable: false),
                        VideoID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CategorySubjectTopicVideoID)
                .ForeignKey("dbo.CategorySubjectTopics", t => t.CategorySubjectTopicID, cascadeDelete: true)
                .ForeignKey("dbo.Videos", t => t.VideoID, cascadeDelete: true)
                .Index(t => t.CategorySubjectTopicID)
                .Index(t => t.VideoID);
            
            CreateTable(
                "dbo.Videos",
                c => new
                    {
                        VideoID = c.Int(nullable: false, identity: true),
                        Number = c.Int(nullable: false),
                        YoutubeID = c.String(),
                        Title = c.String(),
                        Size = c.String(),
                        SolutionVideoYoutubeID = c.String(),
                        SolutionVideoSize = c.String(),
                    })
                .PrimaryKey(t => t.VideoID);
            
            CreateTable(
                "dbo.ChemistryPracticeQuestions",
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
            
            CreateTable(
                "dbo.MathPracticeQuestions",
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
            
            CreateTable(
                "dbo.PhysicsPracticeQuestions",
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
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.CategorySubjectTopicVideos", "VideoID", "dbo.Videos");
            DropForeignKey("dbo.CategorySubjectTopicVideos", "CategorySubjectTopicID", "dbo.CategorySubjectTopics");
            DropForeignKey("dbo.CategorySubjectTopics", "TopicID", "dbo.Topics");
            DropForeignKey("dbo.CategorySubjectTopics", "CategorySubjectID", "dbo.CategorySubjects");
            DropForeignKey("dbo.CategorySubjects", "SubjectID", "dbo.Subjects");
            DropForeignKey("dbo.CategorySubjects", "CategoryID", "dbo.Categories");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.CategorySubjectTopicVideos", new[] { "VideoID" });
            DropIndex("dbo.CategorySubjectTopicVideos", new[] { "CategorySubjectTopicID" });
            DropIndex("dbo.CategorySubjectTopics", new[] { "TopicID" });
            DropIndex("dbo.CategorySubjectTopics", new[] { "CategorySubjectID" });
            DropIndex("dbo.CategorySubjects", new[] { "SubjectID" });
            DropIndex("dbo.CategorySubjects", new[] { "CategoryID" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.PhysicsPracticeQuestions");
            DropTable("dbo.MathPracticeQuestions");
            DropTable("dbo.ChemistryPracticeQuestions");
            DropTable("dbo.Videos");
            DropTable("dbo.CategorySubjectTopicVideos");
            DropTable("dbo.Topics");
            DropTable("dbo.CategorySubjectTopics");
            DropTable("dbo.Subjects");
            DropTable("dbo.CategorySubjects");
            DropTable("dbo.Categories");
        }
    }
}
