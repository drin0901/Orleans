using GraphQL.Types;
using Movies.Contracts;
using System.Collections.Generic;

namespace Movies.Server.Gql.Types
{
	public class MovieDataGraphType : ObjectGraphType<MovieDataModel>
	{
		public MovieDataGraphType()
		{
			Name = "Sample";
			Description = "A movie data graphtype.";

			Field(x => x.Id, nullable: true).Description("Unique key.");
			Field(x => x.Name, nullable: true).Description("Name.");
			Field(x => x.Key, nullable: true).Description("Key.");
			Field(x => x.Description, nullable: true).Description("Description.");
			Field<List<string>>(x => x.Genres, nullable: true).Description("Genres.");
			Field(x => x.Rate, nullable: true).Description("Rate");
			Field(x => x.Length, nullable: true).Description("Length.");
			Field(x => x.Img, nullable: true).Description("Image.");
		}
	}
}