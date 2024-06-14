using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace ExampleTest2.Models;

public class Items
{
    [Key]
    public int Id { get; set; }
    [MaxLength(100)]
    public string Name { get; set; } = string.Empty;
    public int Weight { get; set; }
    
    public ICollection<Backpacks> Backpacks { get; set; } = new HashSet<Backpacks>();
}