using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Brotender.Models;

namespace Brotender;
[Table("drink_ingredients")]
public class DrinkRating
{
    public DrinkRating(int id, int rating)
    {
        Id = id;
        Rating = rating;
    }
    [Key]
    [Column("id")]
    public int Id { get; set; }
    [Required]
    public Drink Drink { get; set; }
    public int DrinkId { get; set; }
    public int Rating { get; set; }
    public User User { get; set; }
    public int UserId { get; set; }
}