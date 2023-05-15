using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Razor6_PageModel.Models;
using Razor6_PageModel.Services;

namespace Razor6_PageModel.Pages
{
    public class ProductPagesModel : PageModel
    {
        private readonly ILogger<ProductPagesModel> _logger;
        public readonly ProductServices productServices;
        public ProductPagesModel(ILogger<ProductPagesModel> logger, ProductServices _productServices)
        {
            _logger = logger;
            productServices=_productServices;
        }
        public Product product {set;get;}
        public void OnGet(int? id)
        {
            // if(Request.RouteValues["id"]!=null)
            // {
            //     int id = int.Parse(Request.RouteValues["id"].ToString());
            // ViewData["Title"] = $"Du lieu doc tu view Data id = {id}";
            // }else
            // {
            //     ViewData["Title"] = $"Du lieu doc tu view Data id = null";
            // }
            if(id!=null)
            {
                ViewData["Title"] = $"San pham id = {id}";
                product = productServices.FindByID(id.Value);
            }else
            {
                ViewData["Title"] = $"Danh sach san pham";
            }
        }

        // /product/{id:int?}/>handler=lastproduct
        public IActionResult OnGetLastproduct()
        {
            ViewData["Title"] = $"San pham cuoi";
            product = productServices.AllProduct().LastOrDefault();
            if(product !=null)
            {
                return Page();
            }else{
                return this.Content("Khong co san pham cuoi");
            }
        }

        // /product/{id:?int}/?handler=deleteall
        public IActionResult OnGetDeleteall()
        {
             productServices.AllProduct().Clear();
             return RedirectToPage("ProductPage");
        }
        // /product/{id:?int}/?handler=loadall
        public IActionResult OnGetLoadall()
        {
             productServices.LoadProduct();
             return RedirectToPage("ProductPage");
        }
        // post
        public IActionResult OnPostDeleteProduct(int?id)
        {
            if(id!=null)
            {
                product = productServices.FindByID(id.Value);
                if(product!=null)
                {
                    productServices.AllProduct().Remove(product);
                }
            }
            return this.RedirectToPage("ProductPage", new{id= string.Empty});
        }
    }
}
