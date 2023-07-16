using System;
namespace Chores.API.Services.ChoresService
{
	public interface IChoresService
	{
		Task<List<HouseChore>> GetAllChores();

        Task<HouseChore?> GetSingleChore(int id);

        Task<List<HouseChore>> GetChoresByName(string? name);

        Task<List<HouseChore>> AddChore(HouseChore chore);

		Task<List<HouseChore>?> UpdateChore(int id, HouseChore request);

        Task<List<HouseChore>?> DeleteChore(int id);
    }
}

