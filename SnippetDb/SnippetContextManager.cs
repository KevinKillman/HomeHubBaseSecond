using Microsoft.EntityFrameworkCore;
using SnippetDb.Tables;

namespace SnippetDb
{
  public class SnippetContextManager : IDisposable
  {
    SnippetDbContext _context;
    public SnippetContextManager(SnippetDbContext context)
    {
      _context = context;
    }
    public Snippet? GetSnip(int Id)
    {
      return _context.Snippets.Where(s => s.Id == Id).FirstOrDefault();
    }

    public async Task SaveHtmlSnippetAsync(string htmlContent, List<Tag>? tags = null)
    {
      _context.Add<Snippet>(new Snippet()
      {
        Content = htmlContent,
        Title = "Test Entry",
        Subject = "Test"
      });
      await _context.SaveChangesAsync();
    }

    public async Task<List<RelatedTags>> GetRelatedTagsAsync(int TagId)
    {
      return await _context.RelatedTags.Where(x => x.PrimaryTag.Id == TagId)
      .Include(x => x.SecondaryTag)
      .Include(x => x.PrimaryTag).ToListAsync();
    }

    public async Task<List<Tag>> GetTagsAsync()
    {
      return await _context.Tags.ToListAsync();
    }

    public async Task CreateTagRelationAsync(int primaryTagId, int secondaryTagId)
    {
      var tagUnionList = await _context.RelatedTags.Include(x => x.PrimaryTag)
        .Include(x => x.SecondaryTag)
        .Select(x => new { PId = x.PrimaryTag.Id, SId = x.SecondaryTag.Id })
        .ToListAsync();
      if (!tagUnionList.Contains(new { PId = primaryTagId, SId = secondaryTagId }))
      {
        var newRelation = new RelatedTags()
        {
          PrimaryTag = _context.Tags.Where(x => x.Id == primaryTagId).First(),
          SecondaryTag = _context.Tags.Where(x => x.Id == secondaryTagId).First()
        };
        _context.Add(newRelation);
        await _context.SaveChangesAsync();
      }
    }

    public async Task DeleteRelationAsync(int relationId)
    {
      var relation = _context.RelatedTags.Where(x => x.RelatedTagsId == relationId).First();
      _context.Remove(relation);
      await _context.SaveChangesAsync();
    }

    public async Task<List<Snippet>> GetSnips()
    {
      return await _context.Snippets.ToListAsync();
    }

    public async Task SaveChanges()
    {
      await _context.SaveChangesAsync();
    }

    public async Task<Tag> GetTagAsync(int tagId)
    {
      return await _context.Tags.Where(x => x.Id == tagId).FirstAsync();
    }

    public async Task CreateNewTagAsync(string tag)
    {
      _context.Add<Tag>(new Tag()
      {
        Name = tag,
        Description = "testDescription",
      });
      await _context.SaveChangesAsync();
    }

    public async Task<List<int>> GetTagIdsAsync()
    {
      return await _context.Tags.Select(x => x.Id).ToListAsync();
    }

    public List<string> GetTagNames()
    {
      return _context.Tags.Select(x => x.Name).ToList();
    }



    public void Dispose()
    {
      _context.Dispose();
    }
  }
}
