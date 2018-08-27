using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FinanceSpreetail.Models;

namespace FinanceSpreetail.Pages.Transactions
{
    public class EditModel : CategoryNamePageModel
    {
        private readonly FinanceSpreetail.Models.FinanceSpreetailContext _context;

        public EditModel(FinanceSpreetail.Models.FinanceSpreetailContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Transaction Transaction { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Transaction = await _context.Transaction.Include(t => t.category)
				.FirstOrDefaultAsync(m => m.ID == id);

            if (Transaction == null)
            {
                return NotFound();
            }

			PopulateCategoryDropDownList(_context, Transaction.categoryID);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

			var transactionToUpdate = await _context.Transaction.FindAsync(id);

			if (await TryUpdateModelAsync<Transaction>(
				transactionToUpdate,
				"transaction",
				s => s.ID, s => s.categoryID, s => s.name, s => s.amount, s => s.date))
			{
				await _context.SaveChangesAsync();
				return RedirectToPage("./Index");
			}

			PopulateCategoryDropDownList(_context, transactionToUpdate.categoryID);
			return Page();
        }

        private bool TransactionExists(int id)
        {
            return _context.Transaction.Any(e => e.ID == id);
        }
    }
}
