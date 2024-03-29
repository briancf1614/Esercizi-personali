import { Component, OnInit } from '@angular/core';

// Service
import { MyService } from '../my.service';

@Component({
    selector: 'app-my-component-1',
    templateUrl: './my.component1.html',
    styleUrls: ['./my.component1.css'],
    // Incapsula il service a livello di componente
    //providers: [ MyService ]    
})
export class MyComponent1  {

    title = 'My Feature Module 1';
    
    text = 'Testo da pipare';
    secretValue: string = '';

    // Injection del Service
    constructor(private myService: MyService) { }

    ngOnInit() {
        // Chiama il metodo del service
        this.secretValue = this.myService.myServiceMethod();
    }

}
