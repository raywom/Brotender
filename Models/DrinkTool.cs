using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Brotender.Models;

[Table("drink_tools")]
public class DrinkTool
{
    public DrinkTool(int id, int drinkId, int toolId)
    {
        Id = id;
        DrinkId = drinkId;
        ToolId = toolId;
    }

    [Key] [Column("id")] public int Id { get; set; }
    public Drink Drink;
    [Column("drink_id")] public int DrinkId { get; set; }
    public Tool Tool { get; set; }
    [Column("tool_id")] public int ToolId { get; set; }
    
}