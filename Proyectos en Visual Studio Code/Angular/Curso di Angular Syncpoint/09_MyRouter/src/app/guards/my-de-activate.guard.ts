import { CanActivateFn } from '@angular/router';
import { inject } from '@angular/core';

// Service mock
import { LoggedService } from '../service/logged.service';

export const myDeActivateGuard: CanActivateFn = (route, state) => {
    const loggedService = inject(LoggedService);        
    if (loggedService.deactivate) {
        return confirm('Sicuro di voler abbandonare la pagina? \nNon hai salvato i dati');
    }
    return true;
};
