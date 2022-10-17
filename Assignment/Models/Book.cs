using System.ComponentModel.DataAnnotations;

namespace Assignment.Models
{
    public class Book
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="vcl")] 
        public string Name { get; set; }

        [Required]
        public double Price { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string Img { get; set; }
        

        [Required] 
        public int Edition { get; set; }

        [Required]
        [Range(1,int.MaxValue,ErrorMessage ="DIT ME THANG TROnG")]
        public int CategoryID { get; set; }

        public Category Category { get; set; }

        public int AuthorID { get; set; }

        public Author Author { get; set; }
    }
}
