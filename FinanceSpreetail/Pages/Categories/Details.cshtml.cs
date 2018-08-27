using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FinanceSpreetail.Models;

namespace FinanceSpreetail.Pages.Categories
{
    public class DetailsModel : PageModel
    {
        private readonly FinanceSpreetail.Models.FinanceSpreetailContext _context;

        public DetailsModel(FinanceSpreetail.Models.FinanceSpreetailContext context)
        {
            _context = context;
        }

        public Category Category { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Category = await _context.Category.FirstOrDefaultAsync(m => m.ID == id);

            if (Category == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
