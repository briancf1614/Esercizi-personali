import { CanMatchFn } from '@angular/router';

export const myCanMatchGuard: CanMatchFn = (route, state) => {
    
    let isLogged = true;

    if (isLogged) {
        return true;
    } else {
        alert('Area privata: vai al login');
        return false;
    };
};
