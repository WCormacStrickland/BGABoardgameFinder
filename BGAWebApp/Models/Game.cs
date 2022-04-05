using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BGAWebApp.Models
{
    public class Game
    {
        public int Id { get; set; }
        public string? Title { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal Rating { get; set; }
        public string? RecommendCount { get; set; }

        public string? BestCount { get; set; }

        public string? SupportCount { get; set; }

        public string? Link { get; set; }
    }
}
