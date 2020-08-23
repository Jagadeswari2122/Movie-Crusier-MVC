using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace movie_crusier.Models
{
    public class Movies
    {
        public int MovieId { get; set; }

        [Required(ErrorMessage = " Title is required and should be 2-100 characters")]
        public string Title { get; set; }

        [Required(ErrorMessage = "BoxOffice is required and it should be a number")]
        public string BoxOffice { get; set; }

        [Required(ErrorMessage = "DateOfLaunch is required")]
        [DataType(DataType.Date)]
        public string Date { get; set; }

        [Required(ErrorMessage = "Select one Genre")]
        public string Genre { get; set; }

        public string Active { get; set; }
        public string HasTeaser { get; set; }


    }
}
