using System.ComponentModel.DataAnnotations;

namespace SnippetDb.Tables
{
  public class Snippet
  {
    [Key]
    public int Id { get; set; }
    public string Content { get; set; }
    public string Title { get; set; }
    public string Subject { get; set; }
    public IList<Tag> Tags { get; set; }
  }
}
