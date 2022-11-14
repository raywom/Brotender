using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Brotender.Models;

[Table("tools")]
public class Tool
{
    public Tool(int id, string name, string description, string imageUrl)
    {
        Id = id;
        Name = name;
        Description = description;
        ImageUrl = imageUrl;
    }

    [Key] [Column("id")] public int Id { get; set; }
    [Required] public string Name { get; set; }
    public string Description { get; set; }
    [Column("image_url")] public string ImageUrl { get; set; }
    [NotMapped] public ICollection<DrinkTool> DrinkTools;
}