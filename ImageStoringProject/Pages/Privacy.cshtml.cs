using ImageStoringProject.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace ImageStoringProject.Pages
{
    public class PrivacyModel : PageModel
    {
        private readonly AppDbContext _context;

        public PrivacyModel(AppDbContext appDbContext)
        {
            _context = appDbContext;
        }

        public List<Photo> Photos { get; set; }

        [BindProperty]
        public IFormFile ImageFile { get; set; }

        [BindProperty]
        public bool StoreInDatabase { get; set; }


        public void OnGet()
        {
            Photos = _context.Photos.ToList();
        }


        public IActionResult OnPost()
        {
            if (StoreInDatabase)
            {
                SaveFileInDatabase(ImageFile);
            }
            else
            {
                SaveFilePathInDatabase(ImageFile);
            }

            return RedirectToPage("/Privacy");
        }

        private bool SaveFileInDatabase(IFormFile file)
        {
            if (file != null && file.Length > 0)
            {
                using (var ms = new MemoryStream())
                {
                    ImageFile.CopyTo(ms);
                    var imageData = ms.ToArray();

                    var newModel = new Photo
                    {
                        MemberProfileId = 1,
                        PhotoURL = "",
                        ImageContents = imageData,
                        ImageExtension = Path.GetExtension(file.FileName),
                        IsInActive = false,
                    };

                    _context.Photos.Add(newModel);
                    _context.SaveChanges();
                    return true;
                }
            }
            else
            {
                return false;
            }

        }

        private bool SaveFilePathInDatabase(IFormFile file)
        {
            if (file != null && file.Length > 0)
            {

                var extention = Path.GetExtension(file.FileName);

                string fileName = GetFileName(file.FileName);
                var imagePath = Path.Combine("wwwroot", "Images", fileName);
                using (var stream = new FileStream(imagePath, FileMode.Create))
                {
                    file.CopyTo(stream);
                    var newModel = new Photo
                    {
                        MemberProfileId = 1,
                        PhotoURL = "/Images/" + fileName,
                        ImageContents = null,
                        ImageExtension = extention,
                        IsInActive = false,

                    };

                    _context.Photos.Add(newModel);
                    _context.SaveChanges();
                    return true;
                }
            }
            else
            {
                return false;
            }

        }

        public string GetFileName(string fileName)
        {
            DateTime dateTime = DateTime.Now;
            string time = 
                dateTime.Day.ToString() + 
                dateTime.Month.ToString() + 
                dateTime.Year.ToString() + "-" + 
                dateTime.Hour.ToString() + 
                dateTime.Minute.ToString() + 
                dateTime.Second.ToString() + "-" + 
                dateTime.Millisecond.ToString();
            return "member-" + time + Path.GetExtension(fileName);
        }
    }

}
