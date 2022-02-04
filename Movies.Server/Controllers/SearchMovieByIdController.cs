using Microsoft.AspNetCore.Mvc;
using Movies.Contracts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Movies.Server.Controllers
{
	[Route("api/[controller]")]
	public class SearchMovieByIdController : Controller
	{
		private readonly ISampleGrainClient _client;

		public SearchMovieByIdController(
			ISampleGrainClient client
		)
		{
			_client = client;
		}

		// GET api/SearchMovieById/1234
		[HttpGet("{id}")]
		public async Task<SampleDataModel> Get(string id)
		{
			var result = await _client.GetByKey(id).ConfigureAwait(false);

			return result;
		}
	}
}