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
		public int total { get; set; }

		public async Task OnGetAsync()
		{
			DateTime today = DateTime.Today;

			IQueryable<BudgetGroup> data =
				from transaction in _context.Transaction
				where transaction.date.Month == today.Month && transaction.date.Year == today.Year
				group transaction by transaction.categoryID into budgetGroup
				select new BudgetGroup()
				{
					name = budgetGroup.First().category.name,
					amount = budgetGroup.Sum(t => t.amount),
					limit = budgetGroup.First().category.amount
				};

			Budgets = await data.AsNoTracking().ToListAsync();
			total = Budgets.Sum(b => b.amount);
		}


	}
}
