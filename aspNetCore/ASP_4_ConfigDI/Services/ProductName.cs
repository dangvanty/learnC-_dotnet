using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_4_ConfigDI.Services
{
	public class ProductName
	{
		private List<string> Name {set;get;}
		public ProductName()
		{
			Name = new List<string>()
			{
				"iPhone7",
				"Samsung",
				"Nokia"
			};
		}	
		public List<string> GetName()=> Name;
	}
}