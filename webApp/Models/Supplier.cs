using System.ComponentModel.DataAnnotations;

namespace webApp.Models;

public class Supplier
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
}