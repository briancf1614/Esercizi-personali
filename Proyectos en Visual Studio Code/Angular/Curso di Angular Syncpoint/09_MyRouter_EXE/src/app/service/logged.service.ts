import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class LoggedService {

  constructor() { }
  // Mock
  isLogged = true;
  isLoggedChild = true;
  deactivate = true;
}
