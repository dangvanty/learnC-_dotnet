using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EFCore2_Miggration.Models
{
	[Table("article")]
	public class Article
	{
		[Key]
		public int ArticleId {set; get;}

		// [StringLength(100)]
		// public string Title {set;  get;}
		[StringLength(100)]
		public string Title {set;  get;}


	}
}