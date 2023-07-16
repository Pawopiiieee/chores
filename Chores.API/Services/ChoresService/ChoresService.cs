using Chores.Data;
using Chores.Data.Models;
using ChoresAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace Chores.API.Services.ChoresService;

public class ChoresService : IChoresService
{
    private readonly DataContext _context;

    public ChoresService(DataContext context) 
    {
        _context = context;
    }
    public async Task<List<HouseChoreViewModel>> AddChore(HouseChoreViewModel chore)
    {
        var model = MapToDataModel(chore, null);

        _context.Chores.Add(model);

        //save change
        await _context.SaveChangesAsync();

        return await GetAllChores();
    }

    public async Task<List<HouseChoreViewModel>?> DeleteChore(int id)
    {
        var chore = await _context.Chores.FindAsync(id);
        if (chore == null)
            return null;   //can return proper status code

        _context.Chores.Remove(chore);

        //save change
        await _context.SaveChangesAsync();

        return await GetAllChores();
    }

    public async Task<List<HouseChoreViewModel>> GetAllChores()
    {
        var allTasks = await _context.Chores.ToListAsync();

        return allTasks
            .Select(task => MapToViewModel(task, null))
            .ToList();
    }

    public async Task<HouseChoreViewModel?> GetSingleChore(int id)
    {
        var singleChore = await _context.Chores.FindAsync(id);
        if (singleChore == null)
            return null;
        return MapToViewModel(singleChore, null);
    }

    public async Task<List<HouseChoreViewModel>> GetChoresByName(string? name)
    {
        var task = await _context.Chores
            .Where(f => (name == null || f.TaskName == name))
            .ToListAsync();

        return task
            .Select(task => MapToViewModel(task, null))
            .ToList();
    }

    public async Task<List<HouseChoreViewModel>?> UpdateChore(int id, HouseChoreViewModel request) 
    {
        var task = await _context.Chores.FindAsync(id);
        if (task == null)
            return null;

        task.TaskName = request.TaskName;
        task.TaskStatus = request.TaskStatus;
        task.CreateDate = request.CreateDate;
        task.Deadline = request.Deadline;
        //task.AssignedPerson = request.AssignedPerson;

        //save change
        await _context.SaveChangesAsync();

        return await GetAllChores();
    }

    private static HouseChoreViewModel MapToViewModel(HouseChore chore, HouseChoreViewModel? original)
    {
        var viewmodel = original ?? new HouseChoreViewModel();

        viewmodel.Id = chore.Id;
        viewmodel.TaskName = chore.TaskName;
        viewmodel.CreateDate = chore.CreateDate;
        viewmodel.Deadline = chore.Deadline;
        viewmodel.TaskStatus = chore.TaskStatus;

        return viewmodel;
    }

    private static HouseChore MapToDataModel(HouseChoreViewModel chore, HouseChore? original)
    {
        var datamodel = original ?? new HouseChore();

        datamodel.Id = chore.Id;
        datamodel.TaskName = chore.TaskName;
        datamodel.CreateDate = chore.CreateDate;
        datamodel.Deadline = chore.Deadline;
        datamodel.TaskStatus = chore.TaskStatus;

        return datamodel;
    }
}

