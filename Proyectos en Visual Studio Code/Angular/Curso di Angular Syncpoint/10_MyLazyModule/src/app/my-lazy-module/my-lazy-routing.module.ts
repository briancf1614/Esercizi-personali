import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

// Componenti
import { LazyComponent } from './lazy-component/lazy.component';
import { LazyChildComponent } from './lazy-component/lazy-child-component/lazy-child.component';

// Routes
const routes: Routes = [
    {
        path: '', component: LazyComponent,
        // Componenti e moduli figli 
        children: [
            { path: 'lazychildcomponent', component: LazyChildComponent },
            { 
                path: 'lazychildmodule', 
                loadChildren: () => import('./my-lazy-child/my-lazy-child.module').then(m => m.MyLazyChildModule), 
                data: { mypreload: true } 
            }
        ]
    }
];

@NgModule({
    /*
    Grazie al metodo forChild(), destinato ai moduli lazy, Angular sa che l'elenco di rotte
    fornisce percorsi aggiuntivi a quelli 'root'.
    Naturalmente è possibile usare forChild() in più moduli.
    */
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})
export class LazyRoutingModule { }