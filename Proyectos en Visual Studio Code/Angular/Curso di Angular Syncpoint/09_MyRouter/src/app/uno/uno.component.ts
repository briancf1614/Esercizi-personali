import { Component, Input, OnInit } from '@angular/core';

// Router
import { Router } from '@angular/router';

@Component({
    selector: 'app-uno',
    templateUrl: './uno.component.html',
    styleUrls: ['./uno.component.css']
})

export class UnoComponent implements OnInit {
    title = 'Component Uno';

    // Parametri inviati
    myParamMap: any = { id: 3, nome: 'Mara' };
    myQueryParams: any = { id: 4, nome: 'Ciro' };

    constructor(private router: Router) {
        console.log('Costruttore Uno Component');
    }

    // Routing con navigate()
    myNavigateParams() {
        this.router.navigate(['due', this.myParamMap]);
    }
    myNavigateQuerystring() {
        this.router.navigate(['due'], { queryParams: this.myQueryParams });
    }

    ngOnInit() {
        console.log('OnInit Uno Component');
    }    
    ngOnDestroy() {
        console.log('OnDestroy Uno Component');
    }
}
