using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ImageStoringProject.Model
{
    public class Photo
    {
        public int PhotoId { get; set; }
        public int MemberProfileId { get; set; }
        public string PhotoURL { get; set; }
        public byte[]? ImageContents { get; set; }
        public string ImageExtension { get; set; }
        public bool IsInActive { get; set; }

    }
}
