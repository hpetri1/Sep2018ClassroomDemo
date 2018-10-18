using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additional Namespaces
using Chinook.Data.Entities;
using ChinookSystem.DAL;
using System.ComponentModel; //ODS
using Chinook.Data.DTOs;
using Chinook.Data.POCOs;
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

        //Sep 17, 2018
        //added this methods for the ODSCRUD.aspx Page
        [DataObjectMethod(DataObjectMethodType.Insert, false)]
        public int Album_Add(Album item)
        {
            using (var context = new ChinookContext())
            {
                item = context.Albums.Add(item); //staged it, is not in the DB yet
                context.SaveChanges(); // is in the DB now
                return item.AlbumId; //if I don't want to send anything back I use void instead of public
            }
        }

        [DataObjectMethod(DataObjectMethodType.Update, false)]
        public int Album_Update(Album item)
        {
            using (var context = new ChinookContext())
            {
                item.ReleaseLabel = string.IsNullOrEmpty(item.ReleaseLabel) ? null :
                    item.ReleaseLabel; //if it contains an empry string then I set it to null else I set it the value inside the field
                context.Entry(item).State = System.Data.Entity.EntityState.Modified; //stages the update
                return context.SaveChanges(); //sends the number of rows that were affected
            }
        }

        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public int Album_Delete(Album item)
        {
            return Album_Delete(item.AlbumId);
        }

        public int Album_Delete(int albumid)
        {
            using (var context = new ChinookContext())
            {
                var existing = context.Albums.Find(albumid);
                if (existing == null)
                {
                    throw new Exception("Album does not exist on file.");
                }

                context.Albums.Remove(existing);
                return context.SaveChanges();
            }
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public List<AnAlbum> Album_GetAlbumAndSongs()
        {
            using (var context = new ChinookContext())
            {
               
                //Create a list of albums showing its title and artist.
                //Show albums with 15 or more tracks only.
                //For each album show the songs on the album and their length.

                var results = from x in context.Albums
                                where x.Tracks.Count() > 24
                                select new AnAlbum
                                {
                                    artist = x.Artist.Name,
                                    title = x.Title,
                                    songs = (from y in x.Tracks
                                            select new Song
                                            {
                                                songname = y.Name,
                                                length = y.Milliseconds / 60000 + ":" + (y.Milliseconds % 60000) / 1000
                                            }).ToList()

                                };

                return results.ToList();               
            }
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public List<SelectionList> List_AlbumTitles()
        {
            using (var context = new ChinookContext())
            {
                var results = from x in context.Albums
                              orderby x.Title
                              select new SelectionList
                              {
                                  IDValueField = x.AlbumId,
                                  DisplayText = x.Title
                              };

                return results.ToList();
            }            
        }

    }
}
