using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Brotender.Models;

namespace Brotender;

[Table("drink_rating")]
public class DrinkRating
{
    public DrinkRating(int id, int rating)
    {
        Id = id;
        Rating = rating;
    }

    [Key] [Column("id")] public int Id { get; set; }
    [NotMapped] public Drink Drink { get; set; }
    [Column("drink_id")] public int DrinkId { get; set; }
    public int Rating { get; set; }
    [NotMapped] public User User;
    [Column("user_id")] public int UserId { get; set; }
}