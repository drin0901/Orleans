using GraphQL.Types;
using Movies.Contracts;
using System.Threading.Tasks;

namespace Movies.Server.Gql.App
{
	public class AppGraphMutation : ObjectGraphType
	{
		private readonly IMovieGrainClient _movieService;

		public AppGraphMutation(IMovieGrainClient movieService)
		{
			_movieService = movieService;
		}

		public Task<MovieDataModel> CreateMovie(MovieDataModel input) => _movieService.AddMovie(input);

		public Task<MovieDataModel> EditMovie(MovieDataModel input) => _movieService.EditMovie(input);

		public Task<MovieDataModel> DeleteMovie(int input) => _movieService.DeleteMovie(input);

	}
}