using System.ComponentModel.DataAnnotations;
namespace ExampleTest2.Models;

public class Titles
{
    [Key]
    public int Id { get; set; }
    [MaxLength(100)]
    public string Name { get; set; } = string.Empty;
    public CharactersTitles CharacterTitle = null!;
    
}