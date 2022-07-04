using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TtopAcademy.API.ApplicationCore.Entities;
using TtopAcademy.API.ApplicationCore.Entities.PracticeQuestions;

namespace TtopAcademy.API.ApplicationCore.ApplicationDbContext
{
    /// <summary> Interface for declaring database tables </summary> 
    public interface IApplicationDbContext : IDisposable
    {
        DbSet<Category> Categories { get; set; }
        DbSet<CategorySubject> CategorySubjects { get; set; }
        DbSet<CategorySubjectTopic> CategorySubjectTopics { get; set; }
        DbSet<CategorySubjectTopicVideo> CategorySubjectTopicVideos { get; set; }
        DbSet<Subject> Subjects { get; set; }
        DbSet<Topic> Topics { get; set; }
        DbSet<Video> Videos { get; set; }

        DbSet<ChemistryPracticeQuestion> ChemistryPracticeQuestions { get; set; }
        DbSet<MathPracticeQuestion> MathPracticeQuestions { get; set; }
        DbSet<PhysicsPracticeQuestion> PhysicsPracticeQuestions { get; set; }
        DbSet<OtherPracticeQuestion> OtherPracticeQuestions { get; set; }  

        Task<int> SaveChangesAsync(); 
    }
}
