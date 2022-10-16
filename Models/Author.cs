using System;
using System.Collections.Generic;

namespace ASM_1670.Models
{
    public class Author
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Dob { get; set; }
        public string Img { get; set; }
        public ICollection<Book> Books { get; set; }
    }
}
