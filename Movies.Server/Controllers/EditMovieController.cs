using Microsoft.AspNetCore.Mvc;
using Movies.Contracts;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movies.Server.Controllers
{
	[Route("api/[controller]")]
	public class EditMovieController : Controller
	{
		private readonly ISampleGrainClient _client;

		public EditMovieController(
			ISampleGrainClient client
		)
		{
			_client = client;
		}

		//POST api/sampledata/1234
		[HttpPost("{id}")]
		public Task<SampleDataModel> EditMovie([FromRoute] string id, string key, string name, string description, string genre, string rate, string length, string image)
		{
			var strGenre = !string.IsNullOrEmpty(genre) ? genre : "";
			var listgenre = strGenre.Split(',');
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

			var result = _client.EditMovie(strObject);
			

			return result;
		}
	}
}