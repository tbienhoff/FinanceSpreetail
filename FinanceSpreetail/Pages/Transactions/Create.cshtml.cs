using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using FinanceSpreetail.Models;

namespace FinanceSpreetail.Pages.Transactions
{
    public class CreateModel : CategoryNamePageModel
    {
        private readonly FinanceSpreetail.Models.FinanceSpreetailContext _context;

        public CreateModel(FinanceSpreetail.Models.FinanceSpreetailContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
			PopulateCategoryDropDownList(_context);
            return Page();
        }

        [BindProperty]
        public Transaction Transaction { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

			var emptyTransaction = new Transaction();

			if(await TryUpdateModelAsync<Transaction>(
				emptyTransaction,
				"transaction",
				s => s.ID, s => s.categoryID, s => s.name, s => s.amount, s => s.date))
			{
				_context.Transaction.Add(emptyTransaction);
				await _context.SaveChangesAsync();
				return RedirectToPage("./Index");
			}

			PopulateCategoryDropDownList(_context, emptyTransaction.categoryID);
			return Page();

        }
    }
}