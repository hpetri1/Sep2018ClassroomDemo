<Query Kind="Expression">
  <Connection>
    <ID>446af3a4-6f1f-40e6-9fea-61af0e814659</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>Chinook</Database>
  </Connection>
</Query>

// find all albums released between 2007 and 2010 inclusive
from x in Albums
where x.ReleaseYear >= 2007 && x.ReleaseYear <= 2010
select x

//find all customers who are from the US, order by lastname then firstname
from x in Customers
where x.Country.Equals("USA")
orderby x.LastName, x.FirstName
select x

//find all US customers who have an email using yahoo.
//Show only the customer full name and email
from x in Customers
where x.Country.Equals("USA") && x.Email.Contains("yahoo")
select new
{
	FullName = x.LastName + ", " + x.FirstName,
	Email = x.Email
}

//Create an alphabetic list of Albums showing title and release year. Include the Artist name
from x in Albums
orderby x.Title
select new
{
	Title = x.Title,
	Year = x.ReleaseYear,
	ArtistName = x.Artist.Name
}

//List the albums for U2, showing title and release year. Order by release year.
from x in Albums
where x.Artist.Name.Contains("U2")
orderby x.ReleaseYear
select new
{
	Title = x.Title,
	Year = x.ReleaseYear,
	//ArtistName = x.Artist.Name
}
