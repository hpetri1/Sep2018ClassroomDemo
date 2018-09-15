using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additional Namespaces
using Chinook.Data.Entities;
using ChinookSystem.DAL;
using System.ComponentModel; //ODS
#endregion

namespace ChinookSystem.BLL
{
    [DataObject]
    public class AlbumController
    {
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public List<Album> Album_List()
        {
            using (var context = new ChinookContext())
            {
                return context.Albums.ToList();
            }
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public Album Album_Find(int albumid)
        {
            using (var context = new ChinookContext())
            {
                return context.Albums.Find(albumid);
            }
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public List<Album> Album_GetByArtistId(int artistid)
        {
            using (var context = new ChinookContext())
            {
                // using Linq here instead of the SQL statement
                var results = from aRowOn in context.Albums  /* to use the DbSet albums*/
                              where aRowOn.ArtistId.Equals(artistid) // In SQL this means: Select albumid, title, artistid, releaseYear, releaseLabel from Albums Where ArtistId = @artistid
                              select aRowOn;
                return results.ToList();
            }
        }
    }
}
