using Autofac.Extras.Moq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Movies.Contracts;
using Movies.GrainClients;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OlreansMovies.Tests
{
    [TestClass]
    public class MovieTest
    {
        [TestMethod]
        public void GetListMovies_ValidCall()
        {
			using (var mock = AutoMock.GetLoose())
			{
				//Arrange
				mock.Mock<IMovieGrainClient>()
					.Setup(x => x.GetListMovies())
					.Returns(GetMoviesData());

				//Act
				var ctr = mock.Create<MoviesGrainClient>();
				var expected = GetMoviesData();
				var actual = ctr.GetListMovies();

				//Assert
				Assert.IsTrue(actual != null);
				Assert.AreEqual(expected.Result.Count(), actual.Result.Count(), "Getting list of movies are not equal");
			}
        }

		[TestMethod]
		public void GetTopMovies_ValidCall()
		{
			using (var mock = AutoMock.GetLoose())
			{
				//Arrange
				mock.Mock<IMovieGrainClient>()
					.Setup(x => x.GetTopMovies());

				//Act
				var ctr = mock.Create<MoviesGrainClient>();
				var expected = 5;
				var actual = ctr.GetTopMovies();

				//Assert
				Assert.IsTrue(actual != null);
				Assert.AreEqual(expected, actual.Result.Count(), "Results of Top 5 Movies are not correct");
			}
		}

		private Task<List<MovieDataModel>> GetMoviesData() => Task.FromResult(MovieDataService.GetListMovies());
	}
}
