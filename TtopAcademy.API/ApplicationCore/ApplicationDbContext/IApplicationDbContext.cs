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
        /// <summary> Adds one time password (OTP) table. </summary>
        DbSet<Otp> Otps { get; set; }

        /// <summary> Adds Categories table. </summary>
        DbSet<Category> Categories { get; set; }

        /// <summary> Adds CategorySubjects table. </summary>
        DbSet<CategorySubject> CategorySubjects { get; set; }

        /// <summary> Adds CategorySubjectTopics table. </summary>
        DbSet<CategorySubjectTopic> CategorySubjectTopics { get; set; }

        /// <summary> Adds CategorySubjectTopicVideos table. </summary>
        DbSet<CategorySubjectTopicVideo> CategorySubjectTopicVideos { get; set; }

        /// <summary> Adds Subjects table. </summary>
        DbSet<Subject> Subjects { get; set; }

        /// <summary> Adds Topics table. </summary>
        DbSet<Topic> Topics { get; set; }

        /// <summary> Adds Videos table. </summary>
        DbSet<Video> Videos { get; set; }

        /// <summary> Adds ChemistryPracticeQuestions table. </summary>
        DbSet<ChemistryPracticeQuestion> ChemistryPracticeQuestions { get; set; }

        /// <summary> Adds MathPracticeQuestions table. </summary>
        DbSet<MathPracticeQuestion> MathPracticeQuestions { get; set; }

        /// <summary> Adds PhysicsPracticeQuestions table. </summary>
        DbSet<PhysicsPracticeQuestion> PhysicsPracticeQuestions { get; set; }

        /// <summary> Adds OtherPracticeQuestions table. </summary>
        DbSet<OtherPracticeQuestion> OtherPracticeQuestions { get; set; }

        /// <summary> Saves pending changes to the database. </summary>
        Task<int> SaveChangesAsync(); 
    }
}
