using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace movie_crusier.Models
{
    public class Favorites
    {
        public int FavoriteId { get; set; }
        public string Title { get; set; }
        public string BoxOffice { get; set; }

        [DataType(DataType.Date)]
        public string Date { get; set; }
        public string Genre { get; set; }
        public string Active { get; set; }

        public string HasTeaser { get; set; }
        public int? MovieId { get; set; }
    }
}
