using Microsoft.AspNetCore.Mvc.Rendering;
using webApp.AppContext;
using webApp.Models;
using webApp.Services.Interfaces;
using webApp.ViewModels;
using webApp.ViewModels.paging;

namespace webApp.Services
{
    public class ProductService : IProductService
    {
        private readonly ApplicationDbContext _context;

        public ProductService(ApplicationDbContext context)
        {
            _context = context;
        }

        public ProductViewModel ShowProducts(int pageId, int take, Search search)
        {
            var result = _context.Products.AsQueryable();
            if (!string.IsNullOrWhiteSpace(search.ProductName))
                result = result.Where(c => c.Name == search.ProductName);

            if (search.SupplierId > 0)
                result = result.Where(c => c.Supplier.Id == search.SupplierId);

            if (search.CategoryId > 0)
                result = result.Where(c => c.Category.Id == search.CategoryId);
            
            var skip = (pageId - 1) * take;

            var model = new ProductViewModel
            {
                Search = new Search()
                {
                    SupplierId = search.SupplierId,
                    CategoryId = search.CategoryId,
                    ProductName = search.ProductName,
                    Suppliers = new SelectList(_context.Suppliers.ToList(),"Id","Name"),
                    Categories = new SelectList(_context.Categories.ToList(),"Id","Name"),

                },
                ShowProducts = result.OrderByDescending(c => c.Id).Skip(skip).Take(take).Select(product => product.Map()).ToList()
            };

            model.GeneratePagging(result,pageId,take);

            return model;
        }
    }
}
