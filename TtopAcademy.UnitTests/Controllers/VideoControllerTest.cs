using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TtopAcademy.API.ApplicationCore.Entities;
using TtopAcademy.API.ApplicationCore.Managers;
using TtopAcademy.API.ApplicationCore.Repositories;
using TtopAcademy.API.Controllers;
using TtopAcademy.API.Infrastructure.Managers.Fakes;
using TtopAcademy.API.Infrastructure.Repositories.Fakes;

namespace TtopAcademy.UnitTests.Controllers
{
    [TestClass]
    public class VideoControllerTest
    {
        [TestMethod]
        public async Task Get_ShouldReturnForCategorySubjectTopicVideoID() 
        {
            List<CategorySubjectTopicVideo> testCategorySubjectTopicVideos = GetTestCegorySubjectTopicVideos();

            IVideoManager fakeVideoManager =
                new FakeVideoManager(testCategorySubjectTopicVideos); 

            VideoController videoController = new VideoController(fakeVideoManager);

            int categorySubjectTopicID = 1;  

            var result = await videoController.Get(categorySubjectTopicID);
            Assert.AreEqual(1, result.Count());
        }

        private List<CategorySubjectTopicVideo> GetTestCegorySubjectTopicVideos()
        {
            var testCategorySubjectTopicVideos = new List<CategorySubjectTopicVideo>
            {
                new CategorySubjectTopicVideo {
                    CategorySubjectTopicVideoID = 1, CategorySubjectTopicID = 1, VideoID = 1,
                    CategorySubjectTopic = new CategorySubjectTopic {
                        CategorySubjectTopicID = 1, CategorySubjectID = 1, TopicID = 1,
                        CategorySubject = new CategorySubject{ CategorySubjectID = 1, CategoryID = 1, SubjectID = 1}
                    },
                    Video = new Video{ VideoID = 1}
                },
                new CategorySubjectTopicVideo {
                    CategorySubjectTopicVideoID = 1, CategorySubjectTopicID = 1, VideoID = 2,
                    CategorySubjectTopic = new CategorySubjectTopic {
                        CategorySubjectTopicID = 1, CategorySubjectID = 1, TopicID = 1,
                        CategorySubject = new CategorySubject{ CategorySubjectID = 1, CategoryID = 1, SubjectID = 1}
                    },
                    Video = new Video{ VideoID = 1}
                }
            };
            return testCategorySubjectTopicVideos;
        }

    }
}
