using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EFCore2_Model.Models
{
	[Table("product")]
	public class Product
	{
	
		[Key]
		public int ProductId {set;get;}
		[Required]
		[StringLength(50)]
		public string ProductName {set;get;}
		[Required]
		[Column(TypeName ="DECIMAL(15,3)")]
		public decimal Price {set;get;}
		public int CateID {set;get;}

		// Create FK--
		[ForeignKey("CateID")] // --> tao 1 truong la CateFK trong bang Product
		[Required]
		public virtual Category Category{set;get;} // FK_ -> PK : tao khoa ngoai tuong ung voi khoa chinh

		public int? CateID2 {set;get;} // cho phep null
		// Create FK--
		[ForeignKey("CateID2")] // --> tao 1 truong la CateFK trong bang Product
		[InverseProperty("Products")]
		public virtual Category Category2 {set;get;} 
	
		public void PrintInfor()=>Console.WriteLine($"{ProductId} - {ProductName} - {Price} - {CateID}");
	}
}