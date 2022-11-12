namespace Brotender.Model;

public class DrinkIngredient
{
    public int Id { get; set; }
    public int DrinkId { get; set; }
    public int IngredientId { get; set; }
    public float Amount { get; set; }
}