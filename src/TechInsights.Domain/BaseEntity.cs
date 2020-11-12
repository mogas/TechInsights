using System;
using System.ComponentModel.DataAnnotations;

namespace TechInsights.Domain
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
    }
}
