using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Brotender.Models;

namespace Brotender.Models;

[Table("favorite_drinks")]
public class FavoriteDrink
{
    [Key] [Column("id")] public int Id { get; set; }
    [NotMapped] public User User;
    [Column("user_id")] public int UserId { get; set; }
    [NotMapped] public Drink Drink { get; set; }
    [Column("drink_id")] public int DrinkId { get; set; }
}