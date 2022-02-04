using Movies.Contracts;
using Orleans;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace Movies.GrainClients
{
	public class SampleGrainClient : ISampleGrainClient
	{
		private readonly IGrainFactory _grainFactory;
		private readonly List<SampleDataModel> _movies = new List<SampleDataModel>();

		public SampleGrainClient(
			IGrainFactory grainFactory
		)
		{
			_grainFactory = grainFactory;
		}

		public Task<SampleDataModel> Get(string id)
		{
			var grain = _grainFactory.GetGrain<ISampleGrain>(id);
			return grain.Get();
		}

		public Task Set(string key, string name)
		{
			var grain = _grainFactory.GetGrain<ISampleGrain>(key);
			return grain.Set(name);
		}

		public async Task<SampleDataModel> GetByKey(string key) => await Task.FromResult(MovieDataService.GetById(key));

		public async Task<List<SampleDataModel>> GetListMovies() => await Task.FromResult(MovieDataService.GetListMovies());

		public async Task<IEnumerable<SampleDataModel>> GetTopMovies() => await Task.FromResult(MovieDataService.GetTopMovies());

		public async Task<IEnumerable<SampleDataModel>> GetByGenre(string genre) => await Task.FromResult(MovieDataService.GetByGenre(genre));

		public Task<SampleDataModel> AddMovie(SampleDataModel obj)
		{
			Console.WriteLine(">>> Movie::Adding Movie");
			var movie = MovieDataService.GetListMovies();
			movie.Add(obj);

			return Task.FromResult(obj);
		}

		public Task<SampleDataModel> EditMovie(SampleDataModel obj)
		{
			Console.WriteLine(">>> Movie::Adding Movie");
			var movie = MovieDataService.GetListMovies();
			

			return Task.FromResult(obj);
		}
	}
}