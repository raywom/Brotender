namespace Brotender.Model;

public class DrinkTool
{
    public DrinkTool(int id, int drinkId, int toolId)
    {
        Id = id;
        DrinkId = drinkId;
        ToolId = toolId;
    }

    public int Id { get; set; }
    public int DrinkId { get; set; }
    public int ToolId { get; set; }
}