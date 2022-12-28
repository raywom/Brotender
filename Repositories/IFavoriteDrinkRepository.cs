using Brotender.Models;

namespace Brotender.Repositories;

public interface IFavoriteDrinkRepository
{
    Task<IEnumerable<FavoriteDrink>> GetFavoriteDrinksAsync();
    Task<FavoriteDrink> GetFavoriteDrinkAsync(int id);
    Task<FavoriteDrink> AddFavoriteDrinkAsync(FavoriteDrink favoriteDrink);
    Task<FavoriteDrink> UpdateFavoriteDrinkAsync(FavoriteDrink favoriteDrink);
    Task<FavoriteDrink> DeleteFavoriteDrinkAsync(int id);
}