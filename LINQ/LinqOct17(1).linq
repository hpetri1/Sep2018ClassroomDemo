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
	var results = from x in Albums
				orderby x.Title
				select new SelectionList
				{ 
					IDValueField = x.AlbumId,
					DisplayText = x.Title
				};
	results.Dump();
}

// Define other methods and classes here
public class SelectionList
    {
        public int IDValueField { get; set; }
        public string DisplayText { get; set; }
    }