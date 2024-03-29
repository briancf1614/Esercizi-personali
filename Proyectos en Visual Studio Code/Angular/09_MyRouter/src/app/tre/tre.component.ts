import { ConditionalExpr } from '@angular/compiler';
import { Component, OnInit } from '@angular/core';
import { ActivatedRouteSnapshot, Router, RouterState, RouterStateSnapshot } from '@angular/router';
import { Observable } from 'rxjs';

@Component({
    selector: 'app-tre',
    templateUrl: './tre.component.html',
    styleUrls: ['./tre.component.css']
})
export class TreComponent implements OnInit {

    title = 'Component Tre';
    
    constructor(private router: Router) {
        console.log('Constructor Tre Component');        
    }

    myNavigateParams() {
        this.router.navigate(['tre-uno']);
    }

    ngOnInit() {
        console.log('OnInit Tre Component');
        // RouterState fornisce informazioni sulla rotta attiva da qualunque posizione
        console.log('RouterState Tre: ', this.router.routerState.root.firstChild?.routeConfig?.children);
    }

    ngOnDestroy() {
        console.log('OnDestroy Tre Component');
    }

}
