<Query Kind="Expression">
  <Connection>
    <ID>446af3a4-6f1f-40e6-9fea-61af0e814659</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>Chinook</Database>
  </Connection>
</Query>

//Joins

//www.dotnetlearners.com/linq

//Rules:
// 1. If you have a navigational property between the tables
//	  this sould be your first choice of attack
// 2. If you do NOT have a navigational property THEN you can
//	  do a JOIN of your tables

// Assume for this example that there is no navogational property
// betweeb Artists and Albums

// the frist table to be referenced should be the main processing data pile
// the other table(s) are the support tables to the first table

from x in Albums
join y in Artists on x.ArtistId equals y.ArtistId
select new
       {
	   	Title = x.Title,
		Year = x.ReleaseYear,
		Lable = x.ReleaseLabel == null ? "unknown" : x.ReleaseLabel,
		Artist = y.Name,
		trackcount = x.Tracks.Count()
	   }