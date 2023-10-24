using webApp.ViewModels;

namespace webApp.Services.Interfaces
{
    public interface IProductService
    {
        ProductViewModel ShowProducts(int pageId, int take, Search search);
        ProductFilterViewModel FilterProducts(ProductFilterParams filterParams);
    }

}
