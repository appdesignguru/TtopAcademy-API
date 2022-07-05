using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using TtopAcademy.API.ApplicationCore.ApplicationDbContext;
using TtopAcademy.API.ApplicationCore.Entities;
using TtopAcademy.API.ApplicationCore.Entities.PracticeQuestions;

namespace TtopAcademy.API.Infrastructure.ApplicationDbContext.Fakes
{
    /// <summary> Fake implementation class for ApplicationDbContext. Used for unit testing. </summary>
    public class FakeApplicationDbContext : IApplicationDbContext
    {

        /// <summary> Constructs a new FakeApplicationDbContext. </summary>
        public FakeApplicationDbContext()
        {
            this.Otps = new FakeOtbDbSet();
            this.Categories = new FakeCategoryDbSet();
            this.CategorySubjects = new FakeCategorySubjectDbSet();
            this.CategorySubjectTopics  = new FakeCategorySubjectTopicDbSet();
            this.CategorySubjectTopicVideos = new FakeCategorySubjectTopicVideoDbSet();
            this.Subjects = new FakeSubjectDbSet();
            this.Topics = new FakeTopicDbSet();
            this.Videos = new FakeVideoDbSet();

            this.ChemistryPracticeQuestions = new FakeChemistryPracticeQuestionDbSet();
            this.PhysicsPracticeQuestions = new FakePhysicsPracticeQuestionDbSet();
            this.MathPracticeQuestions = new FakeMathPracticeQuestionDbSet();
            this.OtherPracticeQuestions = new FakeOtherPracticeQuestionDbSet(); 
        }

        public DbSet<Otp> Otps { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<CategorySubject> CategorySubjects { get; set; }
        public DbSet<CategorySubjectTopic> CategorySubjectTopics { get; set; }
        public DbSet<CategorySubjectTopicVideo> CategorySubjectTopicVideos { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Topic> Topics { get; set; }
        public DbSet<Video> Videos { get; set; }

        public DbSet<ChemistryPracticeQuestion> ChemistryPracticeQuestions { get; set; }
        public DbSet<MathPracticeQuestion> MathPracticeQuestions { get; set; }
        public DbSet<PhysicsPracticeQuestion> PhysicsPracticeQuestions { get; set; }
        public DbSet<OtherPracticeQuestion> OtherPracticeQuestions { get; set; }   

        public Task<int> SaveChangesAsync()
        {
            return Task.FromResult(0);
        }

        public void Dispose()
        {

        }
    }
}