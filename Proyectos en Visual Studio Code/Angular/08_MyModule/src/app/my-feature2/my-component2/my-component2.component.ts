import { Component } from '@angular/core';

// Service importato da altro modulo
import { MyService } from '../../my-feature1/my.service';

@Component({
    selector: 'app-my-component-2',
    templateUrl: './my-component2.component.html',
    styleUrls: ['./my-component2.component.css']
})

export class MyComponent2 {
    title = 'My Feature Module 2';
    text = 'Testo da pipare';
    secretValue!: string;
    constructor(private myService: MyService) {}

    ngOnInit() {
        // Chiama il metodo del service
        this.secretValue = this.myService.myServiceMethod();
    }
}
