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
	string username ="HansenB";
	string playlistname="HansenB3";
	var results = from x in PlaylistTracks
					where x.Playlist.UserName.Equals(username)
					&& x.Playlist.Name.Equals(playlistname)
					orderby x.TrackNumber
					select new UserPlaylistTrack
					{
						TrackID = x.TrackId,
						TrackNumber = x.TrackNumber,
						TrackName = x.Track.Name,
						Milliseconds = x.Track.Milliseconds,
						UnitPrice = x.Track.UnitPrice
					};
	results.Dump();
}

// Define other methods and classes here
public class UserPlaylistTrack
    {
        public int TrackID { get; set; }
        public int TrackNumber { get; set; }
        public string TrackName { get; set; }
        public int Milliseconds { get; set; }
        public decimal UnitPrice { get; set; }
    }