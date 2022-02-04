using Microsoft.AspNetCore.Mvc;
using Movies.Contracts;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movies.Server.Controllers
{
	[Route("api/[controller]")]
	public class AddMovieController : Controller
	{
		private readonly ISampleGrainClient _client;

		public AddMovieController(
			ISampleGrainClient client
		)
		{
			_client = client;
		}

		//GET api/GetListMovies/1234
		//[HttpGet]
		//public async Task<List<SampleDataModel>> Get()
		//{
		//	var result = await _client.GetListMovies().ConfigureAwait(false);

		//	return result;
		//}

		//POST api/sampledata/1234
		[HttpPost("{id}")]
		public Task<SampleDataModel> AddMovie([FromRoute] string id, string key, string name, string description, string genre, string rate, string length, string image)
		{
			var listgenre = genre.Split(',');
			List<string> listGenre = listgenre.ToList();

			var strObject = new SampleDataModel
			{
				Id = id,
				Key = key,
				Name = name,
				Description = description,
				Genres = listGenre,
				Rate = rate,
				Length = length,
				Img = image
			};

			var result = _client.AddMovie(strObject);
			

			return result;
		}
	}
}