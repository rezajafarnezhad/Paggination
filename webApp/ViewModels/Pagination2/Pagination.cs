using Microsoft.AspNetCore.Mvc.Rendering;
using webApp.ViewModels.Pagination2;
using webApp.ViewModels.paging;

namespace webApp.ViewModels.Pagination2
{
    public class Pagination
    {
        public int EntityCount { get; private set; }
        public int CurrentPage { get; private set; }
        public int PageCount { get; private set; }
        public int StartPage { get; private set; }
        public int EndPage { get; private set; }
        public int Take { get; private set; }
        public void GeneratePagging(IQueryable<object> data, int pageId, int take)
        {
            EntityCount = data.Count();
            CurrentPage = pageId;
            Take = take;
            PageCount = data.Count() / take;
            if (data.Count() % take > 0)
                PageCount += 1;
            StartPage = ((pageId - 2 <= 0) ? 1 : pageId - 2);
            EndPage = ((pageId + 2 >= PageCount) ? PageCount : pageId + 2);
        }

    }
}


public class ProductFilterViewModel : Pagination
{
    public List<ProductsDto> Products { get; set; } = new();
    public ProductFilterParams FilterParams { get; set; } = new();
}

public class ProductsDto
{
    public int ProductId { get; set; }
    public string Name { get; set; }
    public string CategoryName { get; set; }
    public string SupplierName { get; set; }
    public bool Status { get; set; }
}
public class ProductFilterParams
{
    public int CategoryId { get; set; }
    public int SupplierId { get; set; }
    public string ProductName { get; set; }
    public SelectList Categories { get; set; }
    public SelectList Suppliers { get; set; }
    public int PageId { get; set; } = 1;
    public int Take { get; set; } = 2;
}