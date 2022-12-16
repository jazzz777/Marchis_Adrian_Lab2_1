using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Marchis_Adrian_Lab2.Models;

namespace Marchis_Adrian_Lab2.Data
{
    public class Marchis_Adrian_Lab2Context : DbContext
    {
        public Marchis_Adrian_Lab2Context (DbContextOptions<Marchis_Adrian_Lab2Context> options)
            : base(options)
        {
        }
         
        public DbSet<Marchis_Adrian_Lab2.Models.Book> Book { get; set; } = default!;

        public DbSet<Marchis_Adrian_Lab2.Models.Publisher> Publisher { get; set; }

        public DbSet<Marchis_Adrian_Lab2.Models.Category> Category { get; set; }

        public DbSet<Marchis_Adrian_Lab2.Models.Author> Author { get; set; }

        public DbSet<Marchis_Adrian_Lab2.Models.Member> Member { get; set; }

        public DbSet<Marchis_Adrian_Lab2.Models.Borrowing> Borrowing { get; set; }
    }
}
