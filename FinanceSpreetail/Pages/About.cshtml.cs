using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using FinanceSpreetail.Models;
using FinanceSpreetail.Models.BudgetViewModels;
using Microsoft.EntityFrameworkCore;

namespace FinanceSpreetail.Pages
{
	public class AboutModel : PageModel
	{
		private readonly FinanceSpreetail.Models.FinanceSpreetailContext _context;

		public AboutModel(FinanceSpreetail.Models.FinanceSpreetailContext context)
		{
			_context = context;
		}

		public IList<BudgetGroup> Budgets { get; set; }

		public async Task OnGetAsync()
		{
			IQueryable<BudgetGroup> data =
				from transaction in _context.Transaction
				group transaction by transaction.categoryID into budgetGroup
				select new BudgetGroup()
				{
					name = budgetGroup.First().category.name,
					amount = budgetGroup.Sum(t => t.amount),
					limit = budgetGroup.First().category.amount
				};

			Budgets = await data.AsNoTracking().ToListAsync();
		}


	}
}
