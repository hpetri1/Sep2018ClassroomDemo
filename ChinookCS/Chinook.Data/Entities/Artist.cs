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
    [Table("Artists")]
    public class Artist
    {
        [Key] // or [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity) but don't really need it, it is optional]; For Compound keys: [Key, Column(Order = 1)] for the first one, [Key, Column(Order =2)] for the second one, and so on...
        public int ArtistId { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        [StringLength(120, ErrorMessage = "Name is limited to 120 characters")]
        public string Name { get; set; }

        //navigation properties
        public virtual ICollection<Album> Albums { get; set; } // collection of children, and the table name POINTING TO A CHILD


    }
}
