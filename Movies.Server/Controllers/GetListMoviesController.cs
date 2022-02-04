using Microsoft.AspNetCore.Mvc;
using Movies.Contracts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Movies.Server.Controllers
{
	[Route("api/[controller]")]
	public class GetListMoviesController : Controller
	{
		private readonly ISampleGrainClient _client;

		public GetListMoviesController(
			ISampleGrainClient client
		)
		{
			_client = client;
		}

		// GET api/GetListMovies/1234
		[HttpGet]
		public async Task<List<SampleDataModel>> Get()
		{
			var result = await _client.GetListMovies().ConfigureAwait(false);

			return result;
		}

		// POST api/sampledata/1234
		[HttpPost("{id}")]
		public async Task Set([FromRoute] string id, [FromForm] string name)
			=> await _client.Set(id, name).ConfigureAwait(false);
	}
}