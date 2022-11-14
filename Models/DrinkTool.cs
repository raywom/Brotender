using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Brotender.Models;
[Table("drink_toolss")]
public class DrinkTool
{
    public DrinkTool(int id, int drinkId, int toolId)
    {
        Id = id;
        DrinkId = drinkId;
        ToolId = toolId;
    }
    [Key]
    [Column("id")]
    public int Id { get; set; }
    [Required]
    public Drink Drink { get; set; }
    public int DrinkId { get; set; }
    public Tool Tool { get; set; }
    public int ToolId { get; set; }
}