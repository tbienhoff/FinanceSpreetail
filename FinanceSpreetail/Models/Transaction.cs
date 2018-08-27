using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace FinanceSpreetail.Models
{
	public class Transaction
	{
		public int ID { get; set; }
		public string name { get; set; }
		public int amount { get; set; }
		[DataType(DataType.Date)]
		[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
		public DateTime date { get; set; }
		public Category category { get; set; }
		public int categoryID { get; set; }
	}
}
