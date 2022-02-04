using Movies.Contracts;
using Orleans;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace Movies.GrainClients
{
	public class SampleGrainClient : IMovieGrainClient
	{
		private readonly IGrainFactory _grainFactory;
		MovieDataModel _dbContext;

		public SampleGrainClient(
			IGrainFactory grainFactory
		)
		{
			_grainFactory = grainFactory;
		}

		public Task<MovieDataModel> Get(string id)
		{
			var grain = _grainFactory.GetGrain<IMovieGrain>(id);
			return grain.Get();
		}

		public Task Set(string key, string name)
		{
			var grain = _grainFactory.GetGrain<IMovieGrain>(key);
			return grain.Set(name);
		}

		public async Task<MovieDataModel> GetByKey(string key) => await Task.FromResult(MovieDataService.GetById(key));

		public async Task<List<MovieDataModel>> GetListMovies() => await Task.FromResult(MovieDataService.GetListMovies());

		public async Task<IEnumerable<MovieDataModel>> GetTopMovies() => await Task.FromResult(MovieDataService.GetTopMovies());

		public async Task<IEnumerable<MovieDataModel>> GetByGenre(string genre) => await Task.FromResult(MovieDataService.GetByGenre(genre));

		public async Task<MovieDataModel> AddMovie(MovieDataModel obj)
		{
			Console.WriteLine(">>> Movie::Adding Movie");
			var movie = MovieDataService.GetListMovies();
			movie.Add(obj);

			return await Task.FromResult(obj);
		}

		public async Task<MovieDataModel> EditMovie(MovieDataModel obj)
		{
			Console.WriteLine(">>> Movie::Adding Movie");
			var movie = MovieDataService.GetListMovies();

			return await Task.FromResult(obj);
		}
	}
}