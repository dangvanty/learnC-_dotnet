using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Learn_MVC.Models;
using Learn_MVC.Service;
using Microsoft.AspNetCore.Mvc;

namespace Learn_MVC.Controllers
{
    public class TestController :Controller
    {
        ILogger<TestController> _logger;
        ProductServices productservice;
        IWebHostEnvironment _env;
        public TestController(ILogger<TestController> logger, ProductServices _productservice, IWebHostEnvironment env)
        {
            _logger = logger;
            productservice= _productservice;
            _env=env;
        }
        public string Index()
        {
            return "Test ne";
        }
        public IActionResult helloJson()
        {
            return Json(
                new{
                    name = "hello",
                    price= 09
                }
            );
        }
        public void Header()
        {
            _logger.LogInformation("Log Header");
            Response.Headers.Add("nice","key moi ne");
        }
        public IActionResult View1()
        {
            string productName = "nice";
            // return View("/Myviews/Test/Test1.cshtml",productName);
            return View((object)productName);
        }
        public IActionResult LocalRedirect()
        {
            var url = Url.Action("Index","Home");
            return LocalRedirect(url);
        }
        public IActionResult Redirect()
        {
            var url = "https://google.com";
            return Redirect(url);
        }
        public IActionResult Content()
        {
            string content = @"hello
            My name is Tydang
            nice to meet you";
            return Content(content,"text/plain");
        }
        public IActionResult Product(int? id=null)
        {
            if(id!=null)
            {

                var product = productservice.Where(p=>p.ID == id).FirstOrDefault();
                if(product==null)
                {
                    TempData["checkProduct"] = "khong co san pham nay";
                    var url= Url.Action("Index","Home");
                    return Redirect(url);
                }
                _logger.LogInformation($"{product.Name}_________");
                ViewData["product"] = product;
                 ViewData["Title"] = product.Name;
                return View();
            }else{

            var products = productservice;
            ViewData["product"] = new Product(){ID=90,Name="jdlf"};
            ViewData["listProduct"] = products;
            ViewData["Title"] = "Danh sach san pham";
            return View();
            }
        }
        public IActionResult FileShow()
        {
            string pathImag = Path.Combine(_env.ContentRootPath,"Images","anh1.jpg");
            var bytes = System.IO.File.ReadAllBytes(pathImag);
            return File(bytes,"image/jpg");
        }
    }
}