using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Assignment.Models
{
    public class Author
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [DataType(DataType.Date)]
        public DateTime DoB { get; set; }

        [Required]
        public string Img { get; set; }

        [Required]
        public string Description { get; set; }

        public ICollection<Book> BookList { get; set; }
    }
}
