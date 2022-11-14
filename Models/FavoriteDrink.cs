using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Brotender.Models;

namespace Brotender.Models;
[Table("favorite_drinks")]
public class FavoriteDrink
{
    [Key]
    [Column("id")]
    public int Id { get; set; }
    [Required]
    public User User { get; set; }
    public int UserId { get; set; }
    public Drink Drink { get; set; }
    public int DrinkId { get; set; }
}