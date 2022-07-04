using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TtopAcademy.API.ApplicationCore.ApplicationDbContext;
using TtopAcademy.API.ApplicationCore.Factories;
using TtopAcademy.API.ApplicationCore.Repositories;
using TtopAcademy.API.Infrastructure.Repositories.Real.PracticeQuestions;

namespace TtopAcademy.API.Infrastructure.Factories.Real 
{
    /// <summary> Practice question factory class. </summary> 
    public class PracticeQuestionFactory : IPracticeQuestionFactory
    {
        private readonly IApplicationDbContext context;

        /// <summary> Constructs a new practice question factory with given parameter. </summary> 
        public PracticeQuestionFactory(IApplicationDbContext context)
        {
            this.context = context; 
        }

        public IPracticeQuestionRepository CreatePracticeQuestionRepository(string subjectName)
        {
            subjectName = subjectName.ToLower();
            switch (subjectName)
            {
                case "chemistry":
                    return new ChemistryPracticeQuestionRepository(context);
                case "mathematics":
                    return new MathPracticeQuestionRepository(context);
                case "physics":
                    return new PhysicsPracticeQuestionRepository(context);
                default:
                    return new OtherPracticeQuestionRepository(context); 
            }
        }
    }
}