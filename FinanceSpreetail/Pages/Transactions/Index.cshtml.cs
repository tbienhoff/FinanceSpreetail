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
			NameSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
			DateSort = sortOrder == "Date" ? "date_desc" : "Date";
			AmountSort = sortOrder == "Amount" ? "amount_desc" : "Amount";

			IQueryable<Transaction> tranactionIQ = from s in _context.Transaction select s;

			switch (sortOrder)
			{
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
				default:
					tranactionIQ = tranactionIQ.OrderBy(s => s.name);
					break;
			}

			Transaction = await tranactionIQ.AsNoTracking().ToListAsync();
		}

		public string NameSort { get; set; }
		public string AmountSort { get; set; }
		public string DateSort { get; set; }

		public string CurrentFilter { get; set; }
		public string CurrentSort { get; set; }
	}
}
