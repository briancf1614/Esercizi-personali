import { CanActivateFn } from '@angular/router';
import { inject } from '@angular/core';
import { Router } from '@angular/router';

// Service
import { LoggedService } from '../service/logged.service';

export const myActivateGuard: CanActivateFn = (route, state) => {    
    // route: informazioni sulla rotta associata al componente
    console.log('Route: ' + route);
    // state: informazioni su un albero di rotte attivate
    console.log('State: ' + state);
    const loggedService = inject(LoggedService);
    const router = inject(Router);  
    if (loggedService.isLogged && route.paramMap.get('role')==='Admin') {
        return true;
    } else {
        alert('Area privata: vai al login');
        // Naviga alla rotta
        router.navigate(['uno']);
        return false;
    }   
};
