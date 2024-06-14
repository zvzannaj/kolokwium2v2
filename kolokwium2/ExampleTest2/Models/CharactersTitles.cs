using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ExampleTest2.Models;

[Table("charactes_titles")]
[PrimaryKey(nameof(CharacterId), nameof(TitleId))]
public class CharactersTitles
{
    public int CharacterId { get; set; }
    public int TitleId { get; set; }
    public DateTime AcquiredAt { get; set; }
    [ForeignKey(nameof(CharacterId))]
    public Characters Character { get; set; } = null!;
    [ForeignKey(nameof(TitleId))]
    public Titles Title { get; set; } = null!;
}