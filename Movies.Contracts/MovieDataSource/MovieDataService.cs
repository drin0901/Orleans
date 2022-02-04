﻿using Movies.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace Movies.Contracts
{
	// todo: perhaps store in json - load and map as needed
	public static class MovieDataService
	{
		private static readonly List<MovieDataModel> Movies = new List<MovieDataModel>
		{
			new MovieDataModel {Id = "1", Key = "deadpool", Name = "Deadpool", Description = "A former Special Forces operative turned mercenary is subjected to a rogue experiment that leaves him with accelerated healing powers, adopting the alter ego Deadpool.", Genres = new List<string> { "action", "adventure", "comedy" }, Rate = "8.6", Length = "1hr 48mins", Img = "deadpool.jpg" },
			new MovieDataModel {Id = "2", Key = "we-are-the-millers", Name = "We're the Millers", Description = "A veteran pot dealer creates a fake family as part of his plan to move a huge shipment of weed into the U.S. from Mexico.", Genres = new List<string> { "adventure", "comedy", "crime" }, Rate = "7.0", Length = "1hr 50mins", Img = "we-are-the-millers.jpg" },
			new MovieDataModel {Id = "3", Key = "straight-outta-compton", Name = "Straight Outta Compton", Description = "The group NWA emerges from the mean streets of Compton in Los Angeles, California, in the mid-1980s and revolutionizes Hip Hop culture with their music and tales about life in the hood.", Genres = new List<string> { "biography", "drama", "history" }, Rate = "8.0", Length = "2hr 27mins", Img = "straight-outta-compton.jpg" },
			new MovieDataModel {Id = "4", Key = "gridiron-gang", Name = "Gridiron Gang", Description = "Teenagers at a juvenile detention center, under the leadership of their counselor, gain self-esteem by playing football together.", Genres = new List<string> { "crime", "drama", "sport" }, Rate = "6.9", Length = "2hr 5mins", Img = "gridiron-gang.jpg" },
			new MovieDataModel {Id = "5", Key = "american-gangster", Name = "American Gangster", Description = "In 1970s America, a detective works to bring down the drug empire of Frank Lucas, a heroin kingpin from Manhattan, who is smuggling the drug into the country from the Far East.", Genres = new List<string> { "biography", "crime", "drama" }, Rate = "7.8", Length = "2hr 37mins", Img = "american-gangster.jpg" },
			new MovieDataModel {Id = "6", Key = "gangster-squad", Name = "Gangster Squad", Description = "It's 1949 Los Angeles, the city is run by gangsters and a malicious mobster, Mickey Cohen. Determined to end the corruption, John O'Mara assembles a team of cops, ready to take down the ruthless leader and restore peace to the city.", Genres = new List<string> { "action", "crime", "drama" }, Rate = "6.8", Length = "1hr 53mins", Img = "gangster-squad.jpg" },
			new MovieDataModel {Id = "7", Key = "now-you-see-me", Name = "Now You See Me", Description = "An FBI agent and an Interpol detective track a team of illusionists who pull off bank heists during their performances and reward their audiences with the money.", Genres = new List<string> { "crime", "mystery", "thriller" }, Rate = "7.3", Length = "1hr 55mins", Img = "now-you-see-me.jpg" },
			new MovieDataModel {Id = "8", Key = "jurassic-world", Name = "Jurassic World", Description = "A new theme park is built on the original site of Jurassic Park. Everything is going well until the park's newest attraction--a genetically modified giant stealth killing machine--escapes containment and goes on a killing spree.", Genres = new List<string> { "action", "adventure", "scifi" },Rate = "7.1", Length = "2hr 4mins", Img = "jurassic-world.jpg" },
			new MovieDataModel {Id = "9", Key = "mission-impossible-rogue-nation", Name = "Mission = Impossible = Rogue Nation", Description = "Ethan and team take on their most impossible mission yet, eradicating the Syndicate - an International rogue organization as highly skilled as they are, committed to destroying the IMF.", Genres = new List<string> { "action", "adventure", "thriller" }, Rate = "7.5", Length = "2hr 11mins", Img = "mission-impossible-rogue-nation.jpg" },
			new MovieDataModel {Id = "10", Key = "the-man-from-uncle", Name = "The Man from U.N.C.L.E.", Description = "In the early 1960s, CIA agent Napoleon Solo and KGB operative Illya Kuryakin participate in a joint mission against a mysterious criminal organization, which is working to proliferate nuclear weapons.", Genres = new List<string> { "action", "adventure", "thriller" }, Rate = "7.3", Length = "1hr 56mins", Img = "the-man-from-uncle.jpg" },
			new MovieDataModel {Id = "11", Key = "spectre", Name = "Spectre", Description = "A cryptic message from Bond's past sends him on a trail to uncover a sinister organization. While M battles political forces to keep the secret service alive, Bond peels back the layers of deceit to reveal the terrible truth behind SPECTRE.", Genres = new List<string> { "action", "adventure", "thriller" }, Rate = "6.9", Length = "2hr 28mins", Img = "spectre.jpg" },
			new MovieDataModel {Id = "12", Key = "legend", Name = "Legend", Description = "The film tells the story of the identical twin gangsters Reggie and Ronnie Kray, two of the most notorious criminals in British history, and their organised crime empire in the East End of London during the 1960s.", Genres = new List<string> { "biography", "crime", "drama" }, Rate = "7.0", Length = "2hr 28mins", Img = "legend.jpg" },
			new MovieDataModel {Id = "13", Key = "southpaw", Name = "Southpaw", Description = "Boxer Billy Hope turns to trainer Tick Wills to help him get his life back on track after losing his wife in a tragic accident and his daughter to child protection services.", Genres = new List<string> { "action", "drama", "sport" }, Rate = "7.5", Length = "2hr 4mins", Img = "southpaw.jpg" },
			new MovieDataModel {Id = "14", Key = "bridge-of-spies", Name = "Bridge of Spies", Description = "During the Cold War, an American lawyer is recruited to defend an arrested Soviet spy in court, and then help the CIA facilitate an exchange of the spy for the Soviet captured American U2 spy plane pilot, Francis Gary Powers.", Genres = new List<string> { "biography", "drama", "thriller" }, Rate = "7.7", Length = "2hr 22mins", Img = "bridge-of-spies.jpg" },
			new MovieDataModel {Id = "15", Key = "ant-man", Name = "Ant-Man", Description = "Armed with a super-suit with the astonishing ability to shrink in scale but increase in strength, cat burglar Scott Lang must embrace his inner hero and help his mentor, Dr. Hank Pym, plan and pull off a heist that will save the world.", Genres = new List<string> { "action", "adventure", "scifi" }, Rate = "7.4", Length = "1hr 57mins", Img = "ant-man.jpg" },
			new MovieDataModel {Id = "16", Key = "fast-and-furious-7", Name = "Fast & Furious 7", Description = "Deckard Shaw seeks revenge against Dominic Toretto and his family for his comatose brother.", Genres = new List<string> { "action", "crime", "thriller" }, Rate = "7.3", Length = "2hr 17mins", Img = "fast-and-furious-7.jpg" },
			new MovieDataModel {Id = "17", Key = "tracers", Name = "Tracers", Description = "Wanted by the Chinese mafia, a New York City bike messenger escapes into the world of parkour after meeting a beautiful stranger.", Genres = new List<string> { "action", "crime", "drama" }, Rate = "5.6", Length = "1hr 34mins", Img = "tracers.jpg" },
			new MovieDataModel {Id = "18", Key = "running-scared", Name = "Running Scared", Description = "A low-ranking thug is entrusted by his crime boss to dispose of a gun that killed corrupt cops, but things get out of control when the gun ends up in wrong hands.", Genres = new List<string> { "action", "crime", "drama" }, Rate = "7.4", Length = "2hr 2mins", Img = "running-scared.jpg" },
			new MovieDataModel {Id = "19", Key = "the-hangover", Name = "The Hangover", Description = "Three buddies wake up from a bachelor party in Las Vegas, with no memory of the previous night and the bachelor missing. They make their way around the city in order to find their friend before his wedding.", Genres = new List<string> { "comedy" }, Rate = "7.8", Length = "1hr 40mins", Img = "the-hangover.jpg" },
			new MovieDataModel {Id = "20", Key = "project-x", Name = "Project X", Description = "3 high school seniors throw a birthday party to make a name for themselves. As the night progresses, things spiral out of control as word of the party spreads.", Genres = new List<string> { "comedy", "crime" }, Rate = "6.7", Length = "1hr 28mins", Img = "project-x.jpg" },
			new MovieDataModel {Id = "21", Key = "the-dark-knight", Name = "The Dark Knight", Description = "When the menace known as the Joker wreaks havoc and chaos on the people of Gotham, the caped crusader must come to terms with one of the greatest psychological tests of his ability to fight injustice.", Genres = new List<string> { "action", "crime", "drama" }, Rate = "9.0", Length = "2hr 32mins", Img = "the-dark-knight.jpg" },
			new MovieDataModel {Id = "22", Key = "the-tournament", Name = "The Tournament", Description = "Every seven years in an unsuspecting town, The Tournament takes place. A battle royale between 30 of the world's deadliest assassins. The last man standing receiving the $10,000,000 cash prize and the title of Worlds No 1, which itself carries the legendary million dollar a bullet price tag.", Genres = new List<string> { "action", "thriller" }, Rate = "6.1", Length = "1hr 35mins", Img = "the-tournament.jpg" },
			new MovieDataModel {Id = "23", Key = "the-matrix", Name = "The Matrix", Description = "A computer hacker learns from mysterious rebels about the true nature of his reality and his role in the war against its controllers.", Genres = new List<string> { "action", "scifi" }, Rate = "8.7", Length = "2hr 16mins", Img = "the-matrix.jpg" },
			new MovieDataModel {Id = "24", Key = "bad-boys", Name = "Bad Boys", Description = "Two hip detectives protect a murder witness while investigating a case of stolen heroin.", Genres = new List<string> { "action", "comedy", "crime" }, Rate = "6.8", Length = "1hr 59mins", Img = "bad-boys.jpg" }
		};

		public static MovieDataModel GetById(string Id)
			=> Movies.FirstOrDefault(x => x.Id == Id);

		public static List<MovieDataModel> GetListMovies()
			=> Movies;

		public static IEnumerable<MovieDataModel> GetTopMovies()
		{
			var listMovies = Movies.OrderByDescending(x => x.Rate).Take(5);

			return listMovies;
		}

		public static IEnumerable<MovieDataModel> GetByGenre(string genre)
		{
			var listMovies = Movies.Where(x => x.Genres.Contains(genre)).ToList();

			return listMovies;
		}
	}

}