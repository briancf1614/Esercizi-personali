import { AfterContentChecked, AfterContentInit, AfterViewChecked, AfterViewInit, Component, DoCheck, OnDestroy, OnInit } from '@angular/core';
import {MatButtonModule} from '@angular/material/button';
import {MatCardModule} from '@angular/material/card';

@Component({
  selector: 'app-prova',
  standalone: true,
  imports: [MatButtonModule,MatCardModule],
  templateUrl: './prova.component.html',
  styleUrl: './prova.component.css'
})
export class ProvaComponent implements OnInit{
  constructor() {
    console.log("costruttore")
  }
  
  cani = [
    {
      nome:'roger',
      razza:'golden',
      descrizione:`The Shiba Inu is the smallest of the six original and distinct spitz breeds of dog
      from Japan. A small, agile dog that copes very well with mountainous terrain, the Shiba Inu was
      originally bred for hunting.`
    }
  ]
  imagine = "";
  imagine1 = "https://media.gettyimages.com/id/2001961938/photo/close-up-to-a-powerful-open-ocean-wave-breaking-on-reef-with-dramatic-golden-light.jpg?b=1&s=170667a&w=0&k=20&c=kolnXl4ZJNIehVmVEKpIHnDrvt4fHIoex1-o2cavIaw=";
  imagine2 = "https://img-s-msn-com.akamaized.net/tenant/amp/entityid/BB1lrF1F.img?w=768&h=302&m=6";
  isDisabled=false;
  changeStatus() {
    this.isDisabled = !this.isDisabled;
  }
  

  ngOnInit(): void {
    console.log("ngOnInit")
    let counter = 0;
    setInterval(()=>{
      if(counter %2 == 0)
        this.imagine = this.imagine1;
      else
        this.imagine = this.imagine2;
      counter++;
    },1000)
  }
}
