import { Component } from '@angular/core';
import { Task } from 'src/app/Task'; //interface
import { TaskService } from 'src/app/services/task.service';
import { TASKS } from 'src/app/tasks';

@Component({
  selector: 'app-tasks',
  templateUrl: './tasks.component.html',
  styleUrls: ['./tasks.component.css']
})
export class TasksComponent {
	tasks: Task[] = TASKS;

	//add provider in a constructor
	constructor(private taskService: TaskService) {}

	ngOnInit(): void{
		this.taskService.getTasks().subscribe((tasks) => this.tasks) // save val in empty array
	} //call taskservice
}
