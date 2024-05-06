using ImageStoringProject.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ImageStoringProject.Pages
{
    public class IndexModel : PageModel
    {
        private readonly AppDbContext _context;

        public IndexModel(AppDbContext context)
        {
            _context = context;
        }

        public List<Photo> Photos { get; set; }

        public void OnGet()
        {
            Photos = _context.Photos.ToList();
        }
    }
}
