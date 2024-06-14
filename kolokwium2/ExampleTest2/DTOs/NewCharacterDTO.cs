using System.ComponentModel.DataAnnotations;

namespace ExampleTest2.DTOs;

public class NewCharacterDTO
{
    [Required]
    public int EmployeeID { get; set; }
    [Required]
    public DateTime AcceptedAt { get; set; }
    [MaxLength(300)]
    public string? Comments { get; set; } = null;
    [Required]
    public ICollection<NewBackpackDTO> Backpacks { get; set; } = new List<NewBackpackDTO>();
}

public class NewBackpackDTO
{
    [Required]
    public string Name { get; set; } = null!;
    [Required]
    [Range(1, int.MaxValue)]
    public int Amount { get; set; }
}