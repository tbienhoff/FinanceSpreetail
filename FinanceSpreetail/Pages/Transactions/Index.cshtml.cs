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

        public async Task OnGetAsync()
        {
            Transaction = await _context.Transaction.ToListAsync();
        }
    }
}
