using System.Collections.Generic;
using System.Threading.Tasks;

namespace Movies.Contracts
{
	public interface IMovieGrainClient
	{
		Task<MovieDataModel> Get(string id);
		Task Set(string key, string name);
		Task<IEnumerable<MovieDataModel>> GetTopMovies();
		Task<List<MovieDataModel>> GetListMovies();
		Task<MovieDataModel> GetByKey(string id);
		Task<IEnumerable<MovieDataModel>> GetByGenre(string genre);
		Task<MovieDataModel> AddMovie(MovieDataModel obj);
		Task<MovieDataModel> EditMovie(MovieDataModel obj);
	}
}
