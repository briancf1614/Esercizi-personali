/*
I moduli lazy vengono caricati solo quando l'utente passerà alla relativa route. 
Tre sono i passaggi principali per l'impostazione di un modulo lazy:
1. Creare il modulo (ng generate module MyLazy --routing crea anche il modulo di routing del modulo lazy)
2. Non importarlo nel modulo AppModule
(3. Non dichiarare eventuali suoi service providedIn: root)
4. Nelle rotte di Root (app-routing.module) usare la chiave loadChildren
*/

import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
// Modulo di routing del lazy module
import { LazyRoutingModule } from './my-lazy-routing.module';

// Componenti del modulo lazy
import { LazyComponent } from './lazy-component/lazy.component';
import { LazyChildComponent } from './lazy-component/lazy-child-component/lazy-child.component';

// Service del modulo lazy
import { LazyService } from './lazy.service';

@NgModule({
    declarations: [
        LazyComponent,
        LazyChildComponent
    ],
    imports: [
        CommonModule,
        LazyRoutingModule
    ],
    providers: [
        LazyService
    ]
})

export class MyLazyModule { }
