using System;
using Chores.API.Data;

namespace Chores.API.Services.ChoresService
{
	public class ChoresService : IChoresService
	{
        private readonly DataContext _context;
        public ChoresService(DataContext context) 
        {
            _context = context;
        }
        public async Task<List<HouseChore>> AddChore(HouseChore chore)
        {
            _context.Chores.Add(chore);

            //save change
            await _context.SaveChangesAsync();

            return await _context.Chores.ToListAsync();
        }

        public async Task<List<HouseChore>?> DeleteChore(int id)
        {
            var chore = await _context.Chores.FindAsync(id);
            if (chore == null)
                return null;   //can return proper status code

            _context.Chores.Remove(chore);

            //save change
            await _context.SaveChangesAsync();

            return await _context.Chores.ToListAsync();
        }

        public async Task<List<HouseChore>> GetAllChores()
        {
            var allTasks = await _context.Chores.ToListAsync();
            return allTasks;
        }

        public async Task<HouseChore?> GetSingleChore(int id)
        {
            var singleChore = await _context.Chores.FindAsync(id);
            if (singleChore == null)
                return null;
            return singleChore;
        }

        public async Task<List<HouseChore>> GetChoresByName(string? name)
        {
            var task = await _context.Chores
                .Where(f => (name == null || f.TaskName == name)).ToListAsync();
            return task;
        }

        public async Task<List<HouseChore>?> UpdateChore(int id, HouseChore request) 
        {
            var task = await _context.Chores.FindAsync(id);
            if (task == null)
                return null;

            task.TaskName = request.TaskName;
            task.TaskStatus = request.TaskStatus;
            task.CreateDate = request.CreateDate;
            task.Deadline = request.Deadline;
            task.AssignedPerson = request.AssignedPerson;

            //save change
            await _context.SaveChangesAsync();

            return await _context.Chores.ToListAsync();
        }
    }
}

