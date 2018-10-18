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
		string tracksby = "Album";
		int argid = 1;
		var results = from x in Tracks
						where (tracksby.Equals("Artist") && x.Album.ArtistId.Equals(argid))
						|| (tracksby.Equals("Gentre") && x.GenreId.Equals(argid))
						|| (tracksby.Equals("MediaType") && x.MediaTypeId.Equals(argid))
						|| (tracksby.Equals("Album") && x.AlbumId.Equals(argid))
							orderby x.Name
							select new TrackList
							{
								TrackID = x.TrackId,
								Name = x.Name,
								Title = x.Album.Title,
								MediaName = x.MediaType.Name,
								GenreName = x.Genre.Name,
								Composer = x.Composer,
								Milliseconds = x.Milliseconds,
								Bytes = x.Bytes,
								UnitPrice = x.UnitPrice,
							};			
	results.Dump();
}

// Define other methods and classes here
public class TrackList
    {
        public int TrackID { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string MediaName { get; set; }
        public string GenreName { get; set; }
        public string Composer { get; set; }
        public int Milliseconds { get; set; }
        public int? Bytes { get; set; }
        public decimal UnitPrice { get; set; }
    }