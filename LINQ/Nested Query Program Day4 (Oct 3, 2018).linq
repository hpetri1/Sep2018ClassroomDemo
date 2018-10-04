<Query Kind="Expression">
  <Connection>
    <ID>446af3a4-6f1f-40e6-9fea-61af0e814659</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>Chinook</Database>
  </Connection>
</Query>

//grouping of data within itself
// a) bu column
// b) by multiple columns
// c) by an entity

//grouping can be saved temporarily into a dataset and that dataset can be reported on

//the grouping attributesis referred to as the .Key
//multiple attributes or entity use .Key.attribute

//repot albums by ReleaseYear
from x in Albums
group x by x.ReleaseYear into gYear
select gYear

from x in Albums
group x by x.ReleaseYear into gYear
select new
		{
			year = gYear.Key,
			numberofalbumsforyear = gYear.Count(),
			albumandartist = from y in gYear
							select new 
							{
								title = y.Title,
								artist = y.Artist.Name,
								albumsongcount = y.Tracks.Count()
							}
		}
		
//grouping of tracks by Genre Name
//actions against your data BEFORE grouping
//is done against the natural entity attribute
//actions done AFTER grouping MUST refer to the //temporary group dataset
//grouping can be done against a complete Entity
//this type of grouping produces a KEY set of ALL
//Entity attributes
from t in Tracks
where t.Album.ReleaseYear > 2010
group t by t.Genre into gTemp
//select gTemp
orderby gTemp.Count() descending
select new
		{
			genre = gTemp.Key.Name,
			numberof = gTemp.Count()
		}