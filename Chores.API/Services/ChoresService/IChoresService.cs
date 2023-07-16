using ChoresAPI.Models;

namespace Chores.API.Services.ChoresService
{
    public interface IChoresService
	{
		Task<List<HouseChoreViewModel>> GetAllChores();

        Task<HouseChoreViewModel?> GetSingleChore(int id);

        Task<List<HouseChoreViewModel>> GetChoresByName(string? name);

        Task<List<HouseChoreViewModel>> AddChore(HouseChoreViewModel chore);

		Task<List<HouseChoreViewModel>?> UpdateChore(int id, HouseChoreViewModel request);

        Task<List<HouseChoreViewModel>?> DeleteChore(int id);
    }
}

