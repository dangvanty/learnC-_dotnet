using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EFCore2_LinQ.Models
{
	public class Product
	{
		public int ProductId {set;get;}
		public string ProductName {set;get;}
		public decimal Price {set;get;}
		public int CateID {set;get;}

		public virtual Category Category{set;get;} // FK_ -> PK : tao khoa ngoai tuong ung voi khoa chinh

		public int? CateID2 {set;get;} // cho phep null
		public virtual Category Category2 {set;get;} 
	
		public void PrintInfor()=>Console.WriteLine($"{ProductId} - {ProductName} - {Price} - {CateID} - cte2 {CateID2}");
	}
}