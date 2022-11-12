namespace Brotender;

public class DrinkRating
{
    public DrinkRating(int id, int drinkId, int rating, string userEmail)
    {
        Id = id;
        DrinkId = drinkId;
        Rating = rating;
        UserEmail = userEmail;
    }

    public int Id { get; set; }
    public int DrinkId { get; set; }
    public int Rating { get; set; }
    public string UserEmail { get; set; }
}