using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCore2_LinQ.Models
{
    public class CategoryDetail
    {
        public int CategoryDetailID {set;get;}
        public int UserId {set;get;}
        public DateTime Created {set;get;}
        public DateTime Updated {set;get;}
        public int CountCate {set;get;}
        public Category Category {set;get;}
    }
}