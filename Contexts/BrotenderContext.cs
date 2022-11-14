using Brotender.Models;
using Microsoft.EntityFrameworkCore;

namespace Brotender.Context;

public class BrotenderContext : DbContext
{
    public DbSet<Drink> Drinks { get; set; }
    public DbSet<DrinkIngredient> DrinkIngredients { get; set; }
    public DbSet<DrinkRating> DrinkRatings { get; set; }
    public DbSet<DrinkTool> DrinkTools { get; set; }
    public DbSet<Ingredient> Ingredients { get; set; }
    public DbSet<Tool> Tools { get; set; }
    public DbSet<FavoriteDrink> FavoriteDrink { get; set; }

    public DbSet<User> User { get; set; }

    public BrotenderContext(DbContextOptions<BrotenderContext> options)
        : base(options)
    {
        Database.EnsureCreated();
    }
}