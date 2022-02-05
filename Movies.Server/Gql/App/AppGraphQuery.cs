using GraphQL.Types;
using Movies.Contracts;
using Movies.Server.Gql.Types;

namespace Movies.Server.Gql.App
{
	public class AppGraphQuery : ObjectGraphType
	{
		public AppGraphQuery(IMovieGrainClient sampleClient)
		{
			Name = "AppQueries";

			Field<SampleDataGraphType>("GetByKey",
				arguments: new QueryArguments(new QueryArgument<StringGraphType>
				{
					Name = "id"
				}),
				resolve: ctx => sampleClient.GetByKey((int)ctx.Arguments["id"])
			);

			Field<SampleDataGraphType>("GetListMovies",
				arguments: new QueryArguments(new QueryArgument<StringGraphType>
				{
					Name = "id"
				}),
				resolve: ctx => sampleClient.GetListMovies()
			);

			Field<SampleDataGraphType>("GetTopMovies",
				arguments: new QueryArguments(new QueryArgument<StringGraphType>
				{
					Name = "id"
				}),
				resolve: ctx => sampleClient.GetTopMovies()
			);

			Field<SampleDataGraphType>("GetByGenre",
				arguments: new QueryArguments(new QueryArgument<StringGraphType>
				{
					Name = "id"
				}),
				resolve: ctx => sampleClient.GetByGenre(ctx.Arguments["genre"].ToString())
			);
		}
	}
}
