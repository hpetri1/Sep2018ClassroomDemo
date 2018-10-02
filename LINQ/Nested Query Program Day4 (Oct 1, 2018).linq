<Query Kind="Program">
  <Connection>
    <ID>446af3a4-6f1f-40e6-9fea-61af0e814659</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>Chinook</Database>
  </Connection>
</Query>

void Main()
{
	//Create a list of albums showing its title and artist.
	//Show albums with 15 or more tracks only.
	//For each album show the songs on the album and their length.
	
	var results = from x in Albums
					where x.Tracks.Count() > 24
					select new AnAlbum
					{
						artist = x.Artist.Name,
						title = x.Title,
						songs = (from y in x.Tracks
								select new Song
								{
									songname = y.Name,
									length = y.Milliseconds/60000 + ":" + (y.Milliseconds%60000)/1000
								}).ToList()
					
					};
	
	results.Dump();
}

// Define other methods and classes here
//Song is the POCO
public class Song
{
	public string songname{ get; set; }
	public string length{ get; set; }
}

//AnAlbum is DTO. It has structure (a set of data on each instance of the class.) (it has a collection in it)
public class AnAlbum
{
	public string artist{ get; set; }
	public string title{ get; set; }
	public List<Song> songs{ get; set; }  //because we added ToList() above, we changed IEnumerables to List
}