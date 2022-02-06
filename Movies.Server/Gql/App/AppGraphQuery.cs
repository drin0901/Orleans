using GraphQL.Types;
using Movies.Contracts;
using Movies.Server.Gql.Types;
using System;

namespace Movies.Server.Gql.App
{
	public class AppGraphQuery : ObjectGraphType
	{
		public AppGraphQuery(IMovieGrainClient movieClient)
		{
			Name = "AppQueries";

			Field<MovieDataGraphType>("GetByKey",
				arguments: new QueryArguments(new QueryArgument<StringGraphType>
				{
					Name = "id"
				}),
				resolve: ctx => movieClient.GetByKey(Convert.ToInt32(ctx.Arguments["id"]))
			);

			Field<ListGraphType<MovieDataGraphType>>("GetListMovies",
				arguments: new QueryArguments(new QueryArgument<StringGraphType>
				{
					Name = "id"
				}),
				resolve: ctx => movieClient.GetListMovies()
			);

			Field<ListGraphType<MovieDataGraphType>>("GetTopMovies",
				arguments: new QueryArguments(new QueryArgument<StringGraphType>
				{
					Name = "id"
				}),
				resolve: ctx => movieClient.GetTopMovies()
			);

			Field<ListGraphType<MovieDataGraphType>> ("GetByGenre",
				arguments: new QueryArguments(new QueryArgument<StringGraphType>
				{
					Name = "genre"
				}),
				resolve: ctx => movieClient.GetByGenre(ctx.Arguments["genre"].ToString())
			);
		}
	}
}
