import { Component, EventEmitter, Input, Output } from '@angular/core';
import { MyService } from '../../my.service';

@Component({
  selector: 'app-child',
  templateUrl: './child.component.html',
  styleUrl: './child.component.css'
})
export class ChildComponent {
  @Input() text = "My child";
  
  @Output() emitter = new EventEmitter();


  constructor(private myService: MyService) { }
 
  myChildSubjectNext() {
      this.myService.mySubject.next('Next Child A');
  }

  changeText(){
    console.log("ct");
    this.emitter.emit("holaChild 2");
  }
}
