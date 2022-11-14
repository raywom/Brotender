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
    [Required]
    public Drink Drink { get; set; }
    public int DrinkId { get; set; }
    public Ingredient Ingredient { get; set; }
    public int IngredientId { get; set; }
    public float Amount { get; set; }
}