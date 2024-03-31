import { Component } from '@angular/core';
import { MyService } from './my.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'exercise_1';

  text = "My text";

  chageText(){
    this.text = "hola";
  }

  onChangeText($event:any){
    this.text = $event;
  }
  constructor(private myService: MyService) { }
 
    ngOnInit() {
        this.myService.mySubject
        .subscribe({
            next: (value: any) => this.text = value,
            error: error => console.log(error),
            complete: () => console.log('Complete')
        });
    }
}
