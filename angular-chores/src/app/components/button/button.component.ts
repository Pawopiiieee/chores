import { Component, OnInit,Input,Output, EventEmitter } from '@angular/core';

@Component({
  selector: 'app-button',
  templateUrl: './button.component.html',
  styleUrls: ['./button.component.css']
})
export class ButtonComponent {
  @Input() text?: string; //declare button properties
  @Input() color?: string; //if not initialized, then it's either string-undefined
  @Output() btnClick = new EventEmitter();


  onClick() { //to reuse button
    this.btnClick.emit();
  }

}
