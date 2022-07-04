using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TtopAcademy.API.ApplicationCore.ApplicationDbContext;
using TtopAcademy.API.ApplicationCore.Entities;
using TtopAcademy.API.ApplicationCore.Repositories;
using TtopAcademy.API.Infrastructure.ApplicationDbContext.Fakes;
using TtopAcademy.API.Infrastructure.Repositories.Real;

namespace TtopAcademy.UnitTests.Repositories
{
    [TestClass] 
    public class VideoRepositoryTest
    {
        IVideoRepository videoRepository;
        IApplicationDbContext applicationDbContext;
        Video dbEntry; 

        [TestInitialize]
        public async Task InitializeBeforeEachTest() 
        {
            applicationDbContext = new FakeApplicationDbContext();
            videoRepository = new VideoRepository(applicationDbContext);

            // PreSave
            Video video = new Video {
                Number = 1, YoutubeID = "erjfnmmsk", Title = "Add and Sub",
                Size = "10", SolutionVideoYoutubeID = "qdmmekd", SolutionVideoSize = "10"
            };
            dbEntry = await videoRepository.SaveVideoAsync(video);
        }

        [TestCleanup] 
        public void CleanUpAfterEachTest() 
        {
            applicationDbContext.Dispose();
            applicationDbContext = null;
            videoRepository = null;
            dbEntry = null;
        }

        [TestMethod]
        public async Task GetAllAsync_ShouldReturnAll() 
        {
            IEnumerable<Video> results = await videoRepository.GetAllVideosAsync();

            Assert.AreEqual(1, results.Count());
        }

        [TestMethod]
        public async Task SaveVideoAsync_ShouldReturnSavedEntry()
        {
            Video video = new Video {
                Number = 2, YoutubeID = "lmnagysy",Title = "Mult and Div",
                Size = "10",SolutionVideoYoutubeID = "daerdjkk",
                SolutionVideoSize = "10"
            };

            var result = await videoRepository.SaveVideoAsync(video);

            Assert.AreEqual(video.Number, result.Number);
            Assert.AreEqual(video.Title, result.Title);
            Assert.AreEqual(video.YoutubeID, result.YoutubeID);
            Assert.AreEqual(video.SolutionVideoYoutubeID, result.SolutionVideoYoutubeID); 
        }

        [TestMethod]
        public async Task UpdateCategoryAsync_ShouldReturnEditedEntry()
        {
            Video video = new Video {
                VideoID = dbEntry.VideoID, Number = 1,YoutubeID = "erjfnmmsk", Title = "Addition and Sub",
                Size = "10",SolutionVideoYoutubeID = "qdmmekd",
                SolutionVideoSize = "10"
            };
            Video result = await videoRepository.UpdateVideoAsync(video);

            Assert.AreEqual(video.Number, result.Number);
            Assert.AreEqual(video.Title, result.Title);
            Assert.AreEqual(video.YoutubeID, result.YoutubeID);
            Assert.AreEqual(video.SolutionVideoYoutubeID, result.SolutionVideoYoutubeID);
        }


        [TestMethod]
        public async Task DeleteVideoAsync_ShouldReturnDeletedVideo()
        {
            Video result = await videoRepository.DeleteVideoAsync(dbEntry.VideoID);

            Assert.AreEqual(dbEntry.Number, result.Number);
            Assert.AreEqual(dbEntry.Title, result.Title); 
        }
    }
}
