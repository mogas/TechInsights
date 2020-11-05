using System;
using System.ComponentModel.DataAnnotations;

namespace TechInsights.Entities
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }

        public DateTime AddedDate { get; set; } = DateTime.UtcNow;
    }
}
