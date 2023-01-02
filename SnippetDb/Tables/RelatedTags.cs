namespace SnippetDb.Tables
{
  public class RelatedTags
  {
    public int RelatedTagsId { get; set; }
    public virtual Tag PrimaryTag { get; set; }
    public virtual Tag SecondaryTag { get; set; }
  }
}
