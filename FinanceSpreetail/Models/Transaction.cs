using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinanceSpreetail.Models
{
	public class Transaction
	{
		public int ID { get; set; }
		public string name { get; set; }
		public int amount { get; set; }
		public DateTime date { get; set; }
		public Category category { get; set; }
	}
}
