using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace FinanceSpreetail.Pages.Transactions
{
	public class CategoryNamePageModel : PageModel
	{
		public SelectList CategoryNameSL { get; set; }

		public void PopulateCategoryDropDownList(FinanceSpreetail.Models.FinanceSpreetailContext _context,
			object selectedDepartment = null)
		{
			var categoryQuery = from d in _context.Category
								orderby d.name
								select d;

			CategoryNameSL = new SelectList(categoryQuery.AsNoTracking(),
				"ID", "name", selectedDepartment);
		}
	}
}
