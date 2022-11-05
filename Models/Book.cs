using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Policy;

namespace Marchis_Adrian_Lab2.Models
{
    public class Book
    {
        public int Id { get; set; }
        [Display(Name = "Titlul cartii")]
        public string Title { get; set; }
        public string Author { get; set; }

        [Column(TypeName = "decimal(6, 2)")]
        public decimal Price { get; set; }

        [Display(Name = "Data publicarii")]
        [DataType(DataType.Date)]
        public DateTime DataPublicarii { get; set; }

        public int? PublisherId { get; set; }
        public Publisher? Publisher { get; set; }  //navigation property 

        public ICollection<BookCategory>? BookCategories { get; set; }

    }

}

