import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';

@Injectable({
    providedIn: 'root'
})
export class MyService {

    url: string = 'https://jsonplaceholder.typicode.com/comments';

    constructor(private httpClient: HttpClient, private router: Router) { }

    getData() {
        return this.httpClient.get(this.url);
    }
}
