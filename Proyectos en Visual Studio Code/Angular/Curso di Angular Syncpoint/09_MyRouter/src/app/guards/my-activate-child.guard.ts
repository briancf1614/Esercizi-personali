import { CanActivateFn } from '@angular/router';
import { Router } from '@angular/router';
import { inject } from '@angular/core';
// Service mock
import { LoggedService } from '../service/logged.service';

export const myActivateChildGuard: CanActivateFn = (route, state) => {
    /* ActivatedRoute fornisce metodi per attraversare in alto e in basso l'albero di route 
    per ottenere informazioni da route padre, figlio e di pari livello.
    */
    // route: informazioni sulla rotta associata al componente
    console.log('Route: ' + route);
    // state: informazioni su un albero di rotte attivate
    console.log('State: ', state); 
    // Accede al paramMap della rotta parent
    console.log('State paramMap: ', state.root.children[0].paramMap.get('role')); 

    const loggedService = inject(LoggedService);    
    const router = inject(Router);
    
    if (loggedService.isLoggedChild) {
        return true;
    } else {
        alert('Area privata: vai al login');
        // Naviga alla pagina
        router.navigate(['uno']);
        return false;
    }
};
