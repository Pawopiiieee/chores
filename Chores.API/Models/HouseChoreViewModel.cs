using Chores.Data.Enums;

namespace ChoresAPI.Models;

public class HouseChoreViewModel
{
	public int Id { get; set; }
	public string TaskName { get; set; } = string.Empty;
	public HouseChoreStatus TaskStatus { get; set; }
    public DateTime CreateDate { get; set; }
    public DateTime Deadline { get; set; }
	public PersonViewModel? AssignedPerson { get; set; }
}

