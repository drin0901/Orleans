using Microsoft.AspNetCore.Mvc;
using Movies.Contracts;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movies.Server.Controllers
{
	[Route("api/[controller]")]
	public class MoviesController : Controller
	{
		private readonly IMovieGrainClient _client;

		public MoviesController(
			IMovieGrainClient client
		)
		{
			_client = client;
		}

		// GET api/GetTopMovies/1234
		[HttpGet("GetTopMovies")]
		public async Task<IEnumerable<MovieDataModel>> GetTopMovies()
		{
			var result = await _client.GetTopMovies().ConfigureAwait(false);

			return result;
		}

		// GET api/GetListMovies/1234
		[HttpGet("GetListMovies")]
		public async Task<List<MovieDataModel>> GetListMovies()
		{
			var result = await _client.GetListMovies().ConfigureAwait(false);

			return result;
		}

		// GET api/GetMovieById/1234
		[HttpGet("GetMovieById")]
		public async Task<MovieDataModel> GetMovieById(int id)
		{
			var result = await _client.GetByKey(id).ConfigureAwait(false);

			return result;
		}

		// GET api/SearchMovieByGenre/1234
		[HttpGet("GetMovieByGenre")]
		public async Task<IEnumerable<MovieDataModel>> GetMovieByGenre(string genre)
		{
			var result = await _client.GetByGenre(genre).ConfigureAwait(false);

			return result;
		}

		//POST api/AddMovie/1234
		[HttpPost("AddMovie")]
		public async Task<MovieDataModel> AddMovie(MovieDataModel objMovie)
		{
			var result = await _client.AddMovie(objMovie).ConfigureAwait(false);

			return result;

		}

		[HttpPut("EditMovie")]
		public async Task<MovieDataModel> EditMovie(MovieDataModel objMovie)
		{
			var result = await _client.EditMovie(objMovie).ConfigureAwait(false);

			return result;
		}
	}
}