namespace SnippetDb.Tables
{
  public class Tag
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public IList<Snippet> Snippets { get; set; }
  }
}
