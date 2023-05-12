using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_5_ConfigJson.Options
{
	public class TestOption
	{
		public string opt_key1 {set;get;}
		public Option2 opt_key2 {set;get;}

	}
	public class Option2
	{
		public string k1{set;get;}
		public string k2{set;get;}
	}
}