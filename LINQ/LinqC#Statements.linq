<Query Kind="Statements">
  <Connection>
    <ID>446af3a4-6f1f-40e6-9fea-61af0e814659</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>Chinook</Database>
  </Connection>
</Query>

//SEPTEMBER 26, 2018
//Using the Statement Language enviroment, we code complete
//C# statements which include the linq query and receiving variable.
//The statements will end with the semi-colon (;)
//To see the contents of the receiving, you will use the LinqPad command .Dump()
//.Dump() is NOT a C# method. It is a LinqPad method.

//List the albums for U2, showing title and release year. Order by release year.

var results = from x in Albums
				where x.Artist.Name.Contains("U2")
				orderby x.ReleaseYear
				select new
				{
					Title = x.Title,
					Year = x.ReleaseYear
				};
results.Dump();

//ternary operator
// condition(s) ? true value : false value
var results2 = from x in Albums
				orderby x.ReleaseLabel
				select new
				{
					title = x.Title,
					label = x.ReleaseLabel == null ? "unknown" : x.ReleaseLabel
				};
results2.Dump();

//a list of Albums showing the title and decade of release. Albums from 1970 to 79 are 70's; 1980 to 89 are 80's; 1990 to 99 are 90's; 2000+ are modern

var results3 = from x in Albums
				//orderby x.ReleaseYear
				select new
				{
					title = x.Title,
					//decade = x.ReleaseYear < 1970 ? "old" : (x.ReleaseYear < 1980 ? "70's" : (x.ReleaseYear < 1990 ? "80's" : (x.ReleaseYear < 2000 ? "90's" : "modern"))) //my solution
					decade = x.ReleaseYear >= 1970 && x.ReleaseYear <=1979 ? "70's" :
					(x.ReleaseYear >= 1980 && x.ReleaseYear <=1989 ? "80's" :
					(x.ReleaseYear >= 1990 && x.ReleaseYear <=1999 ? "90's" :
					"Modern"))
					
				};
results3.Dump();



//Situation: I need a value from a query that will be used in another future query

//create a list of Tracks showing the track name and whether the track is longer then
//track average length or shorter or of the average.

//The first query is obtaining a value that will be used in a future step
var resultaverage = (from x in Tracks
					select x.Milliseconds).Average();
					
//This query is using a value created by a previous query			
var results4 = from x in Tracks
			select new
			{
				Song = x.Name,
				Time = x.Milliseconds,
				Length = x.Milliseconds > resultaverage ? "Long" : 
				(x.Milliseconds < resultaverage ? "Short" : 
					"Average")
			};
resultaverage.Dump();
results4.Dump();

//Aggregates
//.Sum(), .Count(), Min(), Max(), .Average()
//aggregates MUST be done against a collection (0, 1 or more rows)

//List all albums with Title, Artist Name, and the number of tracks on that album
var results5 = from x in Albums
				select new
				{
					title = x.Title,
					artist = x.Artist.Name,
					trackcount = x.Tracks.Count()
				};
results5.Dump();


//SEPTEMBER 28, 2018
//Create a list of artists with their albums counts
//ordered by descending album count

var results6 = from x in Artists
				orderby x.Albums.Count() descending
				select new
				{
					artist = x.Name,
					albumcount = x.Albums.Count()
				};
results6.Dump();

//find the maximum number of albums for all artists
// what is the most albums?
var results7 = (from x in Artists
				select x.Albums.Count()).Max();
				
//who is that artist
var results7b = from x in Artists
				where x.Albums.Count() == results7
				select x;
				
var results7c = from x in Artists
				where x.Albums.Count() == (from y in Artists
				select y.Albums.Count()).Max()
				select x;
results7.Dump();
results7b.Dump();
results7c.Dump();


//produce a list of albums which has tracks showing their title, 
//artist, number of tracks on album, total price of all tracks,
//longest, shortest and average track
var results8 = from x in Albums
				where x.Tracks.Count() > 0
				select  new
				{
					title = x.Title,
					artist = x.Artist.Name,
					//number of ICollection records for x
					//numberoftracks = (from y in x.Tracks
					//select y).Count(),
					methodnumberoftracks = x.Tracks.Count(),
					cost = x.Tracks.Sum(y => y.UnitPrice),
					longest = x.Tracks.Max(y => y.Milliseconds),
					shortest = x.Tracks.Min(y => y.Milliseconds),
					average = x.Tracks.Average(y => y.Milliseconds)
				};
results8.Dump();

//list all the Playlist which have at least a track.
//Show the playlist name, number of playlist tracks,
//the cost of the playlist and the total storage size for the playlist.

var results9 = from x in Playlists
				where x.PlaylistTracks.Count() > 0
				select new
				{
					name = x.Name,
					trackcount = x.PlaylistTracks.Count(),
					cost = x.PlaylistTracks.Sum(plt => plt.Track.UnitPrice),
					storage = x.PlaylistTracks.Sum(plt => plt.Track.Bytes/1000)
				};
results9.Dump();































































