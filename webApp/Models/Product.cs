using System.ComponentModel.DataAnnotations;

namespace webApp.Models;

public class Product
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
    public bool Status { get; set; }

    public int CategoryId { get; set; }
    public int SupplierId { get; set; }

    public Category Category { get; set; }
    public Supplier Supplier { get; set; }



}