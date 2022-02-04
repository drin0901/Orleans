using System.Collections.Generic;
using System.Threading.Tasks;

namespace Movies.Contracts
{
	public interface ISampleGrainClient
	{
		Task<SampleDataModel> Get(string id);
		Task Set(string key, string name);
		Task<SampleDataModel> GetByKey(string id);
		Task<List<SampleDataModel>> GetListMovies();
		Task<IEnumerable<SampleDataModel>> GetTopMovies();
		Task<IEnumerable<SampleDataModel>> GetByGenre(string genre);
		Task<SampleDataModel> AddMovie(SampleDataModel obj);
		Task<SampleDataModel> EditMovie(SampleDataModel obj);
	}
}
