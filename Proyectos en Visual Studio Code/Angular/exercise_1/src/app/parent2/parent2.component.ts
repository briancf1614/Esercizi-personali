import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-parent2',
  templateUrl: './parent2.component.html',
  styleUrl: './parent2.component.css'
})
export class Parent2Component {

  @Input() text = "My Parent 2";
}
