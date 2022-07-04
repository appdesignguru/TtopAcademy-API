using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using TtopAcademy.API.ApplicationCore.ApplicationDbContext;
using TtopAcademy.API.ApplicationCore.Entities;
using TtopAcademy.API.ApplicationCore.Entities.PracticeQuestions;

namespace TtopAcademy.API.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager, string authenticationType)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);
            // Add custom user claims here
            return userIdentity;
        }
    }

    /// <summary> ApplicationDbContext implementation class for declaring database tables. </summary>
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>, IApplicationDbContext
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }
        
        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
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
         
    }
}