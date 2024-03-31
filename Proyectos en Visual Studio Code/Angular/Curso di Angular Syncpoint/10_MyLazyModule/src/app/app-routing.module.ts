import { NgModule } from '@angular/core';
// Modulo Routing
import { Routes, RouterModule, PreloadAllModules } from '@angular/router';

// Componenti
import { MyComponent } from './my-component/my.component';

// CanMatch e Preload Strategy
import { myCanMatchGuard } from './guard/my-can-match.guard';
import { MyPreloadStrategy } from './guard/my-preload-strategy';

// Routes
const routes: Routes = [
    // { path: '', redirectTo: 'home', pathMatch: 'full' },
    { path: 'component', component: MyComponent },
    /*
    La sintassi di caricamento lazy usa loadChildren seguito dal path del modulo e il nome della classe del modulo.
    Il modulo lazy verrà caricato solo quando l'utente raggiungerà il suo route.
    N.B. Ovviamente, preloading e canMatch NON ha senso che coesistano
    */
    { path: 'lazymodule', 
      loadChildren: () => import('./my-lazy-module/my-lazy.module').then(m => m.MyLazyModule), 
      data: { mypreload: true }, canMatch: [myCanMatchGuard]
    }
];

@NgModule({
    // Preloading strategy: PreloadAllModules oppure una strategia custom (es. MyPreloadStrategy)
    imports: [RouterModule.forRoot(routes, { preloadingStrategy: MyPreloadStrategy })],
    exports: [RouterModule]
})

export class AppRoutingModule { }
