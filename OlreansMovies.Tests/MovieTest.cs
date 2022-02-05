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
		private Task<List<MovieDataModel>> GetMoviesData() => Task.FromResult(MovieDataService.GetListMovies());

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

		[TestMethod]
		public void GetByKey_ValidCall()
		{
			using (var mock = AutoMock.GetLoose())
			{
				int id = 1;
				//Arrange
				mock.Mock<IMovieGrainClient>()
					.Setup(x => x.GetByKey(id));

				//Act
				var ctr = mock.Create<MoviesGrainClient>();
				var expected = Task.FromResult(MovieDataService.GetById(id));
				var actual = ctr.GetByKey(id);

				//Assert
				Assert.IsTrue(actual != null);
				Assert.AreEqual(expected.Result, actual.Result, "Getting Movie By Key is incorrect");
			}
		}

		[TestMethod]
		public void GetByGenre_ValidCall()
		{
			using (var mock = AutoMock.GetLoose())
			{
				var genre = "";
				//Arrange
				mock.Mock<IMovieGrainClient>()
					.Setup(x => x.GetByGenre(genre));

				//Act
				var ctr = mock.Create<MoviesGrainClient>();
				var expected = MovieDataService.GetByGenre(genre);
				var actual = ctr.GetByGenre(genre);

				//Assert
				Assert.IsTrue(actual != null);
				Assert.AreEqual(expected.Count(), actual.Result.Count(), "Getting Movie By Genre is incorrect");
			}
		}
	}
}
