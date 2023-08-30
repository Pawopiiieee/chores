import { Component } from '@angular/core';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent {
 //ngOnInit() : lifecycle method
 title: string = 'House Chore Tracker';

 toggleAddTask() {
  console.log('toggle');
 }
}
