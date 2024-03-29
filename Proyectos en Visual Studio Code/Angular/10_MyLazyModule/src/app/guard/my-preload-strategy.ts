import { Injectable } from '@angular/core';
import { PreloadingStrategy, Route } from "@angular/router";
import { Observable, EMPTY } from "rxjs";

@Injectable({
    providedIn: 'root'
})

export class MyPreloadStrategy implements PreloadingStrategy {

    preload(route: Route, fn: () => Observable<any>): Observable<any> {
        return this.myCheckPreload(route) ? fn() : EMPTY;
    }
    
    myCheckPreload(route: Route): boolean {
        return route?.data?.["mypreload"];
    }
}