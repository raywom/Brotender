using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Brotender.Models;
[Table("drink_ingredients")]
public class DrinkIngredient
{
    public DrinkIngredient(int id, float amount)
    {
        Id = id;
        Amount = amount;
    }
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [NotMapped] public Drink Drink;
    [Column("drink_id")]
    public int DrinkId { get; set; }

    [NotMapped] public Ingredient Ingredient;
    [Column("ingredient_id")]
    public int IngredientId { get; set; }
    public float Amount { get; set; }
}