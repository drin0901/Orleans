using Microsoft.Extensions.Logging;
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
		private readonly ILogger _logger;

		public MoviesGrainClient(
			IGrainFactory grainFactory, ILogger<MoviesGrainClient> logger
		)
		{
			_grainFactory = grainFactory;
			_logger = logger;
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
			try
			{
				Console.WriteLine(">>> Movie::Getting Movie By ID");
				var result = await Task.FromResult(MovieDataService.GetById(key));
				_logger.LogInformation($@"Get by id:{key} service called ");

				return result;
			}
			catch (Exception ex)
			{
				_logger.LogInformation(ex.Message);
			}

			return null;

		}

		public async Task<List<MovieDataModel>> GetListMovies()
		{
			try
			{
				Console.WriteLine(">>> Movie::Getting All List of Movies");
				var result = await Task.FromResult(MovieDataService.GetListMovies());
				_logger.LogInformation($@"Get List Movies service called ");

				return result;
			}
			catch (Exception ex)
			{
				_logger.LogInformation(ex.Message);
			}

			return null;
		}

		public async Task<IEnumerable<MovieDataModel>> GetTopMovies()
		{
			try
			{
				Console.WriteLine(">>> Movie::Getting Top 5 Movies");
				var result = await Task.FromResult(MovieDataService.GetTopMovies());
				_logger.LogInformation($@"Get Top Movies service called ");

				return result;
			}
			catch (Exception ex)
			{
				_logger.LogInformation(ex.Message);
			}

			return null;

		}

		public async Task<IEnumerable<MovieDataModel>> GetByGenre(string genre)
		{
			try
			{
				Console.WriteLine(">>> Movie::Getting Movies by Genre");
				var result = await Task.FromResult(MovieDataService.GetByGenre(genre));
				_logger.LogInformation($@"Get by Genre:{genre} service called ");

				return result;
			}
			catch (Exception ex)
			{
				_logger.LogInformation(ex.Message);
			}

			return null;

		}

		public async Task<MovieDataModel> AddMovie(MovieDataModel obj)
		{
			try
			{
				Console.WriteLine(">>> Movie::Adding Movie");
				obj.Id = MovieDataService.AutoNumberId();
				obj.Genres = obj.Genres.ConvertAll(x => x.ToLower());
				var movie = MovieDataService.GetListMovies();
				movie.Add(obj);
				_logger.LogInformation($@"Add Movie service called {obj}");

				return await Task.FromResult(obj);
			}
			catch (Exception ex)
			{
				_logger.LogInformation(ex.Message);
			}

			return null;

		}

		public async Task<MovieDataModel> EditMovie(MovieDataModel obj)
		{
			try
			{
				Console.WriteLine(">>> Movie::Editing Movie");
				var movie = MovieDataService.GetById(obj.Id);
				var listMovie = MovieDataService.GetListMovies();
				listMovie.Remove(movie);
				listMovie.Add(obj);
				_logger.LogInformation($@"Edit Movie service called {obj}");

				return await Task.FromResult(obj);
			}
			catch (Exception ex)
			{
				_logger.LogInformation(ex.Message);
			}

			return null;

		}

		public async Task<MovieDataModel> DeleteMovie(int id)
		{
			try
			{
				Console.WriteLine(">>> Movie::Deleting Movie");
				var movie = MovieDataService.GetById(id);
				var listMovie = MovieDataService.GetListMovies();
				listMovie.Remove(movie);
				_logger.LogInformation($@"Delete Movie service called by Id:{id}");

				return await Task.FromResult(movie);
			}
			catch (Exception ex)
			{
				_logger.LogInformation(ex.Message);
			}

			return null;
		}
	}
}