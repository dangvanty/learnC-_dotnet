using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EFCore2_Miggration.Models
{
	public class ArticleTag
	{
		[Key]
		public int ArticleTagId {set;get;}

		public int TagId {set;get;}  // FK

		[ForeignKey("TagId")]
		public Tag Tag {set;get;}

		public int ArticleId {set;get;} // FK

		[ForeignKey("ArticleId")]
		public Article Article {set;get;}


		// quan hệ n-n --> giá trị : 1-1 -- 1-2 
	}
}