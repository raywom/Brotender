using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Brotender.Models;
[Table("Users")]
public class User
{
    [Key]
    [Column("id")]
    public int Id { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public ICollection<DrinkRating> DrinkRatings { get; set; }
    public ICollection<FavoriteDrink> FavoriteDrinks { get; set; }
}