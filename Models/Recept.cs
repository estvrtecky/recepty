using System.ComponentModel.DataAnnotations;

namespace ReceptModel
{
    public class Recept
    {
        public int Id { get; set; }

        [Required]
        public required string Name { get; set; }

        [Required]
        public required string Description { get; set; }

        [Required]
        public required string Ingredients { get; set; }

        [Required]
        public required string Instructions { get; set; }

        [Required]
        public required string Category { get; set; }

        [Required]
        public required string Difficulty { get; set; }

        [Required]
        public required string Time { get; set; }

        [Required]
        public required string Servings { get; set; }

        [Required]
        public required string Author { get; set; }
    }
}