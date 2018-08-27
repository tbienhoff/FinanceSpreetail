using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinanceSpreetail.Models.BudgetViewModels
{
	public class BudgetGroup
	{
		public string name { get; set; }
		public int limit { get; set; }
		public int amount { get; set; }
	}
}
