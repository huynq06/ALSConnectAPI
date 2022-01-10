using AlsConnect.Application.Interfaces;
using AlsConnect.Application.ViewModels.Products;
using AlsConnect.WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace AlsConnect.WebApp.Controllers
{
    public class HomeController : Controller
    {
        IProductService _productService;
        IProductCategoryService _productCategoryService;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, IProductService productService, IProductCategoryService productCategoryService)
        {
            _productService = productService;
            _productCategoryService = productCategoryService;
            _logger = logger;
        }

        public IActionResult Index()
        {
            List<ProductCategoryViewModel> products = _productCategoryService.GetAll();
            int count = products.Count;
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
