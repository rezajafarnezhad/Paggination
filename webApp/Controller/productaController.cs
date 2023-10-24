using Microsoft.AspNetCore.Mvc;
using webApp.Services.Interfaces;

namespace webApp.Controller;

[Route("/a")]
public class productaController : Microsoft.AspNetCore.Mvc.Controller
{

    private readonly IProductService _productService;
    public productaController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpGet]
    public IActionResult Index(ProductFilterParams filterParams)
    {
        var model = _productService.FilterProducts(filterParams);
        return View(model);
    }
}