import { Component } from '@angular/core';
import { GlobalService } from 'src/app/global.service';

@Component({
    selector: 'app-my-child',
    templateUrl: './my-child.component.html',
    styleUrls: ['./my-child.component.css']
})

export class MyChildComponent {
    title: string = 'My ChildComponent';
    myAccessToken!: string;

    constructor(private globalService: GlobalService) {
        this.myAccessToken = this.globalService.myAccessToken;
    }

}
