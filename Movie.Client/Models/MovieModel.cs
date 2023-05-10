using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movie.Client.Models
{
    public class MovieModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Owner { get; set; }
    }
}
