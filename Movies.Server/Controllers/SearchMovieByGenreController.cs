using Microsoft.AspNetCore.Mvc;
using Movies.Contracts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Movies.Server.Controllers
{
	[Route("api/[controller]")]
	public class SearchMovieByGenreController : Controller
	{
		private readonly ISampleGrainClient _client;

		public SearchMovieByGenreController(
			ISampleGrainClient client
		)
		{
			_client = client;
		}

		// GET api/SearchMovieByGenre/1234
		[HttpGet("{genre}")]
		public async Task<IEnumerable<SampleDataModel>> Get(string genre)
		{
			var result = await _client.GetByGenre(genre).ConfigureAwait(false);

			return result;
		}
	}
}