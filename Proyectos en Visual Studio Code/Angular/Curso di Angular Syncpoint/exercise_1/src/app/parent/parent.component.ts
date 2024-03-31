import { Component, EventEmitter, Input, Output } from '@angular/core';

@Component({
  selector: 'app-parent',
  templateUrl: './parent.component.html',
  styleUrl: './parent.component.css'
})
export class ParentComponent {

  @Input() text="My parent 1"

  @Output() emitter = new EventEmitter();



  onChangeText($event: any){

    this.text = $event
    this.changeText($event)
  }
  

  changeText(childArg?:any){
    if(childArg){
      this.emitter.emit(childArg)
    }else{
      this.emitter.emit( "Hola parent")
    }
    
  }

}
