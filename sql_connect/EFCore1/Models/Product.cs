using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EFCore1.Models
{
    [Table("product")]
    public class Product
    {
        [Key]
        public int ProductId {set;get;}
        [Required]
        [StringLength(50)]
        public string ProductName {set;get;}
        [StringLength(50)]
        public string ProductProvider {set;get;}

        public void PrintInfor()=>Console.WriteLine($"{ProductId} - {ProductName} - {ProductProvider}");

    }
}