using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Razor6_PageModel.Models;

namespace Razor6_PageModel.Pages
{
    public class ContactRequestModel: PageModel
    {
        [BindProperty]
        public Contact contacUser{set;get;}
        private readonly ILogger<ContactRequestModel> _logger;
        public ContactRequestModel(ILogger<ContactRequestModel> logger)
        {
            _logger = logger;
            _logger.LogInformation("Innit contact request ...");
        }
        public double Tong(double a, double b)=>a+b;
        public void onPost(Contact _contact)
        {
            Console.WriteLine(_contact.Name);
        }
    }
}