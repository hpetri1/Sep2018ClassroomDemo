using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additional Namespaces
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
#endregion

namespace Chinook.Data.Entities
{
    [Table("Albums")]
    public class Album
    {
        [Key]
        public int AlbumId { get; set; }

        [Required(ErrorMessage = "Title is required.")]
        [StringLength(160, ErrorMessage = "Title is limited to 160 characters")]
        public string Title { get; set; }

        //[Required(ErrorMessage = "Artist ID is required.")] 2.) don't need the validation here as well
        public int ArtistId { get; set; }

        //[Required(ErrorMessage = "Release Year is required.")] 1.) validation here is useless, because the default value of an int is 0, so the field will always have a value in it
        public int ReleaseYear { get; set; }

        [StringLength(50, ErrorMessage = "Release Label is limited to 50 characters")]
        public string ReleaseLabel { get; set; }

        //navigational properties
        public virtual Artist Artist { get; set; } // class, classname POINTING TO A PARENT

        //public virtual ICollection<Track> Tracks { get; set; } POINTING TO A CHILD (this table does not exist in our DB)
    }
}
