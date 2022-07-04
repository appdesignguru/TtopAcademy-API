using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using TtopAcademy.API.ApplicationCore.Entities;
using TtopAcademy.API.ApplicationCore.Entities.PracticeQuestions;

namespace TtopAcademy.API.Infrastructure.ApplicationDbContext.Fakes
{
    public class FakeOtbDbSet : FakeDbSet<Otp>
    {
        public override async Task<Otp> FindAsync(params object[] keyValues)
        {
            return await Task.FromResult(this.SingleOrDefault(entity => entity.OtpID == (int)keyValues.Single()));
        }
    }

    public class FakeCategoryDbSet : FakeDbSet<Category>
    {
        public override async Task<Category> FindAsync(params object[] keyValues) 
        {
            return await Task.FromResult(this.SingleOrDefault(entity => entity.CategoryID == (int)keyValues.Single())); 
        }
    }

    public class FakeCategorySubjectDbSet : FakeDbSet<CategorySubject>
    {
        public override async Task<CategorySubject> FindAsync(params object[] keyValues)
        {
            return await Task.FromResult(this.SingleOrDefault(entity => entity.CategorySubjectID == (int)keyValues.Single()));
        }
    }

    public class FakeCategorySubjectTopicDbSet : FakeDbSet<CategorySubjectTopic>
    {
        public override async Task<CategorySubjectTopic> FindAsync(params object[] keyValues)
        {
            return await Task.FromResult(this.SingleOrDefault(entity => entity.CategorySubjectTopicID == (int)keyValues.Single()));
        }
    }

    public class FakeCategorySubjectTopicVideoDbSet : FakeDbSet<CategorySubjectTopicVideo>
    {
        public override async Task<CategorySubjectTopicVideo> FindAsync(params object[] keyValues)
        {
            return await Task.FromResult(this.SingleOrDefault(entity => entity.CategorySubjectTopicVideoID == (int)keyValues.Single()));
        }
    }

    public class FakeSubjectDbSet : FakeDbSet<Subject>
    {
        public override async Task<Subject> FindAsync(params object[] keyValues)
        {
            return await Task.FromResult(this.SingleOrDefault(entity => entity.SubjectID == (int)keyValues.Single())); 
        }
    }

    public class FakeTopicDbSet : FakeDbSet<Topic>
    {
        public override async Task<Topic> FindAsync(params object[] keyValues)
        {
            return await Task.FromResult(this.SingleOrDefault(entity => entity.TopicID == (int)keyValues.Single())); 
        }
    }

    public class FakeVideoDbSet : FakeDbSet<Video> 
    {
        public override async Task<Video> FindAsync(params object[] keyValues)
        {
            return await Task.FromResult(this.SingleOrDefault(entity => entity.VideoID == (int)keyValues.Single()));  
        }
    }

    public class FakeChemistryPracticeQuestionDbSet : FakeDbSet<ChemistryPracticeQuestion>
    {
        public override async Task<ChemistryPracticeQuestion> FindAsync(params object[] keyValues)
        {
            return await Task.FromResult(this.SingleOrDefault(entity => entity.PracticeQuestionID == (int)keyValues.Single()));
        }
    }
     
    public class FakePhysicsPracticeQuestionDbSet : FakeDbSet<PhysicsPracticeQuestion>
    {  
        public override async Task<PhysicsPracticeQuestion> FindAsync(params object[] keyValues)
        {
            return await Task.FromResult(this.SingleOrDefault(entity => entity.PracticeQuestionID == (int)keyValues.Single()));
        }
    }

    public class FakeMathPracticeQuestionDbSet : FakeDbSet<MathPracticeQuestion>
    {
        public override async Task<MathPracticeQuestion> FindAsync(params object[] keyValues)
        {
            return await Task.FromResult(this.SingleOrDefault(entity => entity.PracticeQuestionID == (int)keyValues.Single()));
        }
    }

    public class FakeOtherPracticeQuestionDbSet : FakeDbSet<OtherPracticeQuestion>
    {
        public override async Task<OtherPracticeQuestion> FindAsync(params object[] keyValues)
        {
            return await Task.FromResult(this.SingleOrDefault(entity => entity.PracticeQuestionID == (int)keyValues.Single()));
        }
    }
} 