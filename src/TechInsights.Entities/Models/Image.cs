using Microsoft.AspNetCore.Http;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace TechInsights.Entities.Models
{
    [Table("Images")]
    public class Image : BaseEntity
    {
        [Column(TypeName = "nvarchar(50)")]
        public string Title { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        [DisplayName("Image Name")]
        public string Name { get; set; }

        [NotMapped]
        [DisplayName("Upload File")]
        public IFormFile File { get; set; }
    }
}
