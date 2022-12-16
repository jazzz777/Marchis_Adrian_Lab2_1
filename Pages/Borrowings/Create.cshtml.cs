﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Marchis_Adrian_Lab2.Data;
using Marchis_Adrian_Lab2.Models;
using Microsoft.EntityFrameworkCore;

namespace Marchis_Adrian_Lab2.Pages.Borrowings
{
    public class CreateModel : PageModel
    {
        private readonly Marchis_Adrian_Lab2.Data.Marchis_Adrian_Lab2Context _context;

        public CreateModel(Marchis_Adrian_Lab2.Data.Marchis_Adrian_Lab2Context context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            var bookList = _context.Book
             .Include(b=> b.Author)
             .Select(x => new
             {
                 x.Id, 
                 BookFullName = x.Title + " - " + x.Author.LastName + " " + x.Author.FirstName
             });
            // "Id" from ID ->
            ViewData["BookID"] = new SelectList(bookList, "Id","BookFullName");
            ViewData["MemberID"] = new SelectList(_context.Member, "ID", "FullName");
            return Page();
        }

        [BindProperty]
        public Borrowing Borrowing { get; set; }
        
        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Borrowing.Add(Borrowing);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
