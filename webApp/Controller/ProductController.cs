using Microsoft.AspNetCore.Mvc;
using webApp.Services.Interfaces;
using webApp.ViewModels;

namespace webApp.Controller;

public class ProductController : Microsoft.AspNetCore.Mvc.Controller
{
    private readonly IProductService _productService;

    public ProductController(IProductService productService)
    {
        _productService = productService;
    }


    [HttpGet]
    public IActionResult Index(Search search, int pageId = 1, int take = 1)
    {
        var result = _productService.ShowProducts(pageId, take, search);
        return View(result);
    }

    [HttpPost]
    public IActionResult LoadTable(Search search, int pageId, int take)
    {
        var result = _productService.ShowProducts(pageId, take, search);
        return PartialView("_ProductsTable",result);
    }
}