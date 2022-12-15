using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
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

    public async Task<List<Snippet>> GetSnips()
    {
      return await _context.Snippets.ToListAsync();
    }

    public void SaveSnips()
    {
      _context.SaveChanges();
    }

    public void Dispose()
    {
      _context.Dispose();
    }
  }
}
