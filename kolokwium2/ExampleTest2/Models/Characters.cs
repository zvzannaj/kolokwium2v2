using System.ComponentModel.DataAnnotations;

namespace ExampleTest2.Models;

public class Characters
{
    [Key]
    public int Id { get; set; }
    [MaxLength(50)]
    public string FirstName{ get; set; }
    [MaxLength(120)]
    public string LastName { get; set; }
    public int CurrentWeight { get; set; }

    public int MaxWeight { get; set; }
    public ICollection<Backpacks> Backpacks { get; set; } = new HashSet<Backpacks>();
    public ICollection<CharactersTitles> CharacterTitle = new HashSet<CharactersTitles>();
}