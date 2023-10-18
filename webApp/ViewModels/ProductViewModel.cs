using System.Reflection.Metadata.Ecma335;
using Microsoft.AspNetCore.Mvc.Rendering;
using webApp.ViewModels.paging;

namespace webApp.ViewModels;

public class ProductViewModel: BasePagging
{
    public List<ShowProducts> ShowProducts { get; set; }=new ();
    public Search  Search { get; set; }
}

public class ShowProducts
{
    public int ProductId { get; set; }
    public string Name { get; set; }
    public string CategoryName { get; set; }
    public string SupplierName { get; set; }
    public bool Status { get; set; }
}
public class Search
{
    public int CategoryId { get; set; }
    public int SupplierId { get; set; }
    public string ProductName { get; set; }
    public SelectList Categories { get; set; }
    public SelectList Suppliers { get; set; }
}