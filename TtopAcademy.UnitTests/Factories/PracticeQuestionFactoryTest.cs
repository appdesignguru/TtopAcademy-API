using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TtopAcademy.API.ApplicationCore.ApplicationDbContext;
using TtopAcademy.API.ApplicationCore.Repositories;
using TtopAcademy.API.Infrastructure.ApplicationDbContext.Fakes;
using TtopAcademy.API.Infrastructure.Factories.Real;

namespace TtopAcademy.UnitTests.Factories
{
    [TestClass]
    public class PracticeQuestionFactoryTest
    {
        [TestMethod]
        public void CreatePracticeQuestionRepository_ShouldReturnAppropiateRepository()
        {
            IApplicationDbContext applicationDbContext = new FakeApplicationDbContext();
            PracticeQuestionFactory practiceQuestionFactory = new PracticeQuestionFactory(applicationDbContext);

            IPracticeQuestionRepository practiceQuestionRepository = practiceQuestionFactory.CreatePracticeQuestionRepository("Physics");
            
            Assert.IsNotNull(practiceQuestionRepository);
        }

        [TestMethod]
        public void CreatePracticeQuestionRepository_ShouldReturnNotNull()
        { 
            IApplicationDbContext applicationDbContext = new FakeApplicationDbContext();
            PracticeQuestionFactory practiceQuestionFactory = new PracticeQuestionFactory(applicationDbContext);

            IPracticeQuestionRepository result = practiceQuestionFactory.CreatePracticeQuestionRepository("ahshwb");

            Assert.IsNotNull(result);
        }
    }
}
