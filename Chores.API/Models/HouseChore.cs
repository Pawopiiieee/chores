using System;

namespace ChoresAPI.Models;

public class HouseChore
{
	public int Id { get; set; }
	public string TaskName { get; set; } = string.Empty;
	public TaskStatus TaskStatus { get; set; }
    public DateTime CreateDate { get; set; }
    public DateTime Deadline { get; set; }
	public Person? AssignedPerson { get; set; }
}

