﻿using System;
using System.Collections.Generic;

namespace ASM_1670.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Price { get; set; }
        public string Img { get; set; }
        public DateTime PublishDate { get; set; }
        public string Description { get; set; }
        
        public int AuthorId { get; set; }
        public Author Author { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
