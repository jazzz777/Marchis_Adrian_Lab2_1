using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Marchis_Adrian_Lab2.Data;
using Marchis_Adrian_Lab2.Models;
using Marchis_Adrian_Lab2.Models.ViewModels;
using System.Security.Policy;

namespace Marchis_Adrian_Lab2.Pages.Categories
{
    public class IndexModel : PageModel
    {
        private readonly Marchis_Adrian_Lab2.Data.Marchis_Adrian_Lab2Context _context;

        public IndexModel(Marchis_Adrian_Lab2.Data.Marchis_Adrian_Lab2Context context)
        {
            _context = context;
        }

        public IList<Category> Category { get;set; } = default!;

        public CategoryIndexData CategoryData { get; set; }
        public int CategoryId { get; set; }
        public int BookID { get; set; }
        public async Task OnGetAsync(int? id, int? bookID)
        {
            CategoryData = new CategoryIndexData();
            CategoryData.Categories = await _context.Category
                .Include(i => i.Books)
                    .ThenInclude(c => c.Author)
                .OrderBy(i => i.CategoryName)
                .ToListAsync();
            if (id != null)
            {
                CategoryId = id.Value;
                Category category = CategoryData.Categories
                    .Where(i => i.Id == id.Value).Single();
                CategoryData.Books = category.Books;
            }
        }
    }
}
