using Microsoft.EntityFrameworkCore;
namespace Brotender;

public class Drink
{
    public Drink(int id, string name, string description, string taste, string preparation)
    {
        Id = id;
        Name = name;
        Description = description;
        Taste = taste;
        Preparation = preparation;
    }

    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Taste { get; set; }
    public string Preparation { get; set; }
    
}