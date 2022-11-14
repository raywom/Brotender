using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Brotender.Models;
using Microsoft.EntityFrameworkCore;
namespace Brotender.Models;
[Table("Drinks")]
public class Drink
{
    public Drink(int id, string name, string description, string taste, string preparation, bool isUserAdded, string imageUrl)
    {
        Id = id;
        Name = name;
        Description = description;
        Taste = taste;
        Preparation = preparation;
        IsUserAdded = isUserAdded;
        ImageUrl = imageUrl;
    }
    [Key]
    [Column("id")]
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    public string Description { get; set; }
    public string Taste { get; set; }
    public string Preparation { get; set; }
    [Column("is_user_added")]
    public bool IsUserAdded { get; set; }
    [Column("image_url")]
    public string ImageUrl { get; set; }
    public ICollection<DrinkIngredient> DrinkIngredients { get; set; }
    public ICollection<DrinkRating> DrinkRatings { get; set; }
    public ICollection<DrinkTool> DrinkTools { get; set; }
}