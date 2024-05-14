import { Injectable } from '@angular/core';

import { Task } from '../Task'; //interface
//import { TASKS } from '../tasks' //task
import { Observable } from 'rxjs';
import {HttpClient, HttpHeaders} from '@angular/common/http'; //API, HTTP client

@Injectable({
  providedIn: 'root'
})
export class TaskService {

	private apiUrl = 'http://localhost:5000/tasks'

  constructor(private http:HttpClient) { }

	getTasks(): Observable<Task[]> { //alternative getTasks2 = () => TASKS
		return this.http.get<Task[]>(this.apiUrl);
	}



}
