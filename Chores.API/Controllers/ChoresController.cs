using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Chores.API.Services.ChoresService;
using ChoresAPI.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ChoresAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ChoresController : ControllerBase
{
    private readonly IChoresService _choresService;

    public ChoresController(IChoresService choresService)
    {
        _choresService = choresService;
    }

    [HttpGet]
    public async Task<ActionResult<List<HouseChoreViewModel>>> GetAllChores()
    {
        return await _choresService.GetAllChores();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<HouseChoreViewModel>> GetSingleChore(int id)
    {
        var result = await _choresService.GetSingleChore(id);
        if(result is null)
        {
            return NotFound("No Task");
        }
        return Ok(result);
    }

    [HttpGet("search")]
    public async Task<ActionResult<List<HouseChoreViewModel>>> GetChoresByName(string? name)
    {
        var result = await _choresService.GetChoresByName(name);
        if (result is null)
        {
            return NotFound("No Task");
        }
        return Ok(result);
    }

    // POST api/values
    [HttpPost]
    public async Task<ActionResult<List<HouseChoreViewModel>>> AddChore(HouseChoreViewModel chore)
    {
        var result = await _choresService.AddChore(chore);
        return Ok(result);
    }

    // PUT api/values/5
    [HttpPut("{id}")]
    public async Task<ActionResult<List<HouseChoreViewModel>>> UpdateChore(int id, HouseChoreViewModel request)
    {
        var result = await _choresService.UpdateChore(id,request);
        if (result is null)
        {
            return NotFound("No Task");
        }
        return Ok(result);
    }

    // DELETE api/values/5
    [HttpDelete("{id}")]
    public async Task<ActionResult<List<HouseChoreViewModel>>> DeleteChore(int id)
    {
        var result = await _choresService.DeleteChore(id);
        if (result is null)
        {
            return NotFound("No Task");
        }
        return Ok(result);
    }
}

