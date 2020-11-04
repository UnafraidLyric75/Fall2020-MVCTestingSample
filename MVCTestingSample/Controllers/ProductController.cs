using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MVCTestingSample.Models;
using MVCTestingSample.Models.Interfaces;

namespace MVCTestingSample.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository _repo;

        public ProductController(IProductRepository repo)
        {
            _repo = repo;
        }

        public async Task<IActionResult> Index()
        {
            List<Product> products = await _repo.GetAllProductsAsync();
            return View(products);
        }
    }
}
