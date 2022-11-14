using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Brotender.Models;
[Table("ingredients")]
public class Ingredient
{
    public Ingredient(int id, string name, string description, string imageUrl, short isAlcohol)
    {
        Id = id;
        Name = name;
        Description = description;
        ImageUrl = imageUrl;
        IsAlcohol = isAlcohol;
    }
    [Key]
    [Column("id")]
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    public string Description { get; set; }
    public string ImageUrl { get; set; }
    public short IsAlcohol { get; set; }
    public ICollection<DrinkIngredient> DrinkIngredients { get; set; }
}