using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Policy;

namespace Marchis_Adrian_Lab2.Models
{
    public class Book
    {
        public int Id { get; set; }

        [Required, StringLength(150, MinimumLength = 3)]
        [Display(Name = "Titlul cartii")]
        public string Title { get; set; }

        // before author.cs ->[RegularExpression(@"^[A-Z][a-z]+\s[A-Z][a-z]+$", ErrorMessage = "Numele autorului trebuie sa fie de forma 'Prenume Nume'"), Required, StringLength(50, MinimumLength = 3)]
        //^ marcheaza inceputul sirului de caractere 
        //[A-Z][a-z]+ prenumele -litera mare urmata de oricate litere mici
        //\s spatiu
        //[A-Z][a-z]+ numele- litera mare urmata de oricate litere mici
        //$ marcheaza sfarsitul sirului de caractere

        [Display(Name = "Autor")]
        public int? AuthorId { get; set; }
        public Author? Author { get; set; }  //navigation property 

        [Range(1, 300)]
        [Display(Name = "Pret")]
        [Column(TypeName = "decimal(6, 2)")]
        public decimal Price { get; set; }

        [Display(Name = "Data publicarii")]
        [DataType(DataType.Date)]
        public DateTime DataPublicarii { get; set; }

        public int? PublisherId { get; set; }
        public Publisher? Publisher { get; set; }  //navigation property ?
        public int? CategoryId { get; set; } //new
        public Category? Category { get; set; } //new
        public ICollection<BookCategory>? BookCategories { get; set; } // navigation property

    }

}

