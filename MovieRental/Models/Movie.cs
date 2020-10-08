using System;
using System.ComponentModel.DataAnnotations;

namespace MovieRental.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageUri { get; set; }
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }
        public Genre Genre { get; set; }

    }

    public enum Genre
    {
        Action = 0,
        Comedy = 1,
        Romance = 2,
        Drama = 3,
        Crime = 4,
        Fantasy = 5,
        Horror = 6,
        Thriller = 7
    }
}
