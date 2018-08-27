using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FinanceSpreetail.Models;

namespace FinanceSpreetail.Pages.Transactions
{
    public class IndexModel : PageModel
    {
        private readonly FinanceSpreetail.Models.FinanceSpreetailContext _context;

        public IndexModel(FinanceSpreetail.Models.FinanceSpreetailContext context)
        {
            _context = context;
        }

        public IList<Transaction> Transaction { get;set; }

		public async Task OnGetAsync(string sortOrder)
		{
			DateSort = String.IsNullOrEmpty(sortOrder) ? "Date" : "";
			NameSort = sortOrder == "Name" ? "name_desc" : "Name";
			AmountSort = sortOrder == "Amount" ? "amount_desc" : "Amount";
			CategorySort = sortOrder == "Category" ? "category_desc" : "Category";

			IQueryable<Transaction> tranactionIQ = from s in _context.Transaction select s;

			switch (sortOrder)
			{
				case "Name":
					tranactionIQ = tranactionIQ.OrderBy(s => s.name);
					break;
				case "name_desc":
					tranactionIQ = tranactionIQ.OrderByDescending(s => s.name);
					break;
				case "Date":
					tranactionIQ = tranactionIQ.OrderBy(s => s.date);
					break;
				case "date_desc":
					tranactionIQ = tranactionIQ.OrderByDescending(s => s.date);
					break;
				case "Amount":
					tranactionIQ = tranactionIQ.OrderBy(s => s.amount);
					break;
				case "amount_desc":
					tranactionIQ = tranactionIQ.OrderByDescending(s => s.amount);
					break;
				case "Category":
					tranactionIQ = tranactionIQ.OrderBy(s => s.category.name);
					break;
				case "category_desc":
					tranactionIQ = tranactionIQ.OrderByDescending(s => s.category.name);
					break;
				default:
					tranactionIQ = tranactionIQ.OrderByDescending(s => s.date);
					break;
			}

			Transaction = await tranactionIQ.Include(t => t.category).AsNoTracking().ToListAsync();
		}

		public string NameSort { get; set; }
		public string AmountSort { get; set; }
		public string DateSort { get; set; }
		public string CategorySort { get; set; }

		public string CurrentFilter { get; set; }
		public string CurrentSort { get; set; }
	}
}
