import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

// Componenti
import { MyLazyGrandChildComponent } from './my-lazy-grand-child/my-lazy-grand-child.component';

// Routes
const routes: Routes = [
    {
        path: '', component: MyLazyGrandChildComponent,       
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
export class LazyChildRoutingModule { }