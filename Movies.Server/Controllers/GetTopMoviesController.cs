using Microsoft.AspNetCore.Mvc;
using Movies.Contracts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Movies.Server.Controllers
{
	[Route("api/[controller]")]
	public class GetTopMoviesController : Controller
	{
		private readonly ISampleGrainClient _client;

		public GetTopMoviesController(
			ISampleGrainClient client
		)
		{
			_client = client;
		}

		// GET api/GetTopMovies/1234
		[HttpGet]
		public async Task<IEnumerable<SampleDataModel>> Get()
		{
			var result = await _client.GetTopMovies().ConfigureAwait(false);

			return result;
		}
	}
}