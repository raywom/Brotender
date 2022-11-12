namespace Brotender.Model;

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

    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string ImageUrl { get; set; }
    public short IsAlcohol { get; set; }

}