using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinanceSpreetail.Models
{
	public class Category
	{
		public int ID { get; set; }
		public int amount { get; set; }

		public ICollection<Transaction> transactions { get; set; }
	}
}
