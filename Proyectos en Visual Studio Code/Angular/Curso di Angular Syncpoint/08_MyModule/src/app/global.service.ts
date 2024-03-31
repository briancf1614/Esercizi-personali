import { Injectable } from '@angular/core';

@Injectable({
    providedIn: 'root'
})
export class GlobalService {
    // Valori 'visibili' globalmente
    myAccessToken: string = 'ABC123';
}
