using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Razor6_PageModel.Models
{
	public class Contact
	{
		[BindProperty]
		[DisplayName("Id nguoi dung")]
		[Range(1,10000, ErrorMessage ="id phai tu 1 - 10000")]
		public int ID {set;get;}	

		[BindProperty]
		[DisplayName("Ten nguoi dung")]
		[StringLength(100, ErrorMessage ="max length 100")]
		public string Name {set;get;}

		[BindProperty]
		[DisplayName("Age nguoi dung")]
		[Range(18,60, ErrorMessage ="tuoi trong khoảng tu 18 - 60")]
		public int Age {set;get;}	

		[BindProperty]
		[DisplayName("Email nguoi dung")]
		[EmailAddress(ErrorMessage ="Email khong dung dinh dang")]
		public string Email {set;get;}
	}
}