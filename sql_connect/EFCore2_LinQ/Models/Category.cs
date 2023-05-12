using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EFCore2_LinQ.Models
{
	[Table("Category")]
	public class Category
	{
		[Key]
		public int CategoryID{set;get;}
		[Required]
		[StringLength(100)]
		[Column("CategoryName")] // ten thay doi ten cho bang
		public string CategoryName {set;get;}
		[Column(TypeName ="text")]
		public string Description {set;get;}
		// Collect navigation
		public virtual List<Product>Products{set;get;}
		public CategoryDetail CategoryDetail {set;get;}
	}
}