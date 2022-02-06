using Movies.Contracts;
using Orleans;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace Movies.GrainClients
{
	public class MoviesGrainClient : IMovieGrainClient
	{
		private readonly IGrainFactory _grainFactory;

		public MoviesGrainClient(
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

		public async Task<MovieDataModel> GetByKey(int key) 
		{
			Console.WriteLine(">>> Movie::Getting Movie By ID");
			var result = await Task.FromResult(MovieDataService.GetById(key));

			return result;
		}

		public async Task<List<MovieDataModel>> GetListMovies()
		{
			Console.WriteLine(">>> Movie::Getting All List of Movies");
			var result = await Task.FromResult(MovieDataService.GetListMovies());

			return result;
		}

		public async Task<IEnumerable<MovieDataModel>> GetTopMovies()
		{
			Console.WriteLine(">>> Movie::Getting Top 5 Movies");
			var result = await Task.FromResult(MovieDataService.GetTopMovies());

			return result;
		}

		public async Task<IEnumerable<MovieDataModel>> GetByGenre(string genre)
		{
			Console.WriteLine(">>> Movie::Getting Movies by Genre");
			var result = await Task.FromResult(MovieDataService.GetByGenre(genre));

			return result;
		}

		public async Task<MovieDataModel> AddMovie(MovieDataModel obj)
		{
			Console.WriteLine(">>> Movie::Adding Movie");
			obj.Id = MovieDataService.AutoNumberId();
			obj.Genres = obj.Genres.ConvertAll(x => x.ToLower());
			var movie = MovieDataService.GetListMovies();
			movie.Add(obj);

			return await Task.FromResult(obj);
		}

		public async Task<MovieDataModel> EditMovie(MovieDataModel obj)
		{
			Console.WriteLine(">>> Movie::Editing Movie");
			var movie = MovieDataService.GetById(obj.Id);
			var listMovie = MovieDataService.GetListMovies();
			listMovie.Remove(movie);
			listMovie.Add(obj);

			return await Task.FromResult(obj);
		}

		public async Task<MovieDataModel> DeleteMovie(int id)
		{
			Console.WriteLine(">>> Movie::Deleting Movie");
			var movie = MovieDataService.GetById(id);
			var listMovie = MovieDataService.GetListMovies();
			listMovie.Remove(movie);

			return await Task.FromResult(movie);
		}
	}
}