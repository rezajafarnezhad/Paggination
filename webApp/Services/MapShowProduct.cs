using webApp.Models;
using webApp.ViewModels;

namespace webApp.Services
{
    public static class MapShowProduct
    {
        public static ShowProducts Map(this Product product)
        {
            var result = new ShowProducts()
            {
                ProductId = product.Id,
                Name = product.Name,
                Status = product.Status,
                CategoryName = product.Category.Name,
                SupplierName = product.Supplier.Name,
            };

            return result;
        }

        public static ProductsDto Map2(this Product product)
        {
            var result = new ProductsDto()
            {
                ProductId = product.Id,
                Name = product.Name,
                Status = product.Status,
                CategoryName = product.Category.Name,
                SupplierName = product.Supplier.Name,
            };

            return result;
        }
    }
}
