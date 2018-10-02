using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region
using Chinook.Data.POCOs;
#endregion

namespace Chinook.Data.DTOs
{

    //AnAlbum is DTO. It has structure (a set of data on each instance of the class.) (it has a collection in it)
    public class AnAlbum
    {
        public string artist { get; set; }
        public string title { get; set; }
        public List<Song> songs { get; set; }  //because we added ToList() above, we changed IEnumerables to List
    }
}
