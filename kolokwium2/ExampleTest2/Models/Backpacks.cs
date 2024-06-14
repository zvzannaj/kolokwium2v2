using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ExampleTest2.Models;

[Table("backpacks")]
[PrimaryKey(nameof(CharacterId), nameof(ItemId))]
public class Backpacks
{
    public int CharacterId { get; set; }
    public int ItemId { get; set; }
    public int Amount { get; set; }
    [ForeignKey(nameof(CharacterId))]
    public Characters Character { get; set; } = null!;
    [ForeignKey(nameof(ItemId))]
    public Items Item { get; set; } = null!;
    
}