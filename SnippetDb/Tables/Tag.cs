using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace SnippetDb.Tables
{
  [Index(nameof(Name), IsUnique = true)]
  public class Tag
  {
    [Key]
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    public string NormalizedName { get => Name.ToUpper(); }
    public string? Description { get; set; }
    public IList<Snippet> Snippets { get; set; }
    public IList<Tag> SecondaryTags { get; set; }
  }
}
