/*
Mentre il modulo AppModule lancia l'applicazione, i moduli features la estendono.
Consentono quindi di dividere l'applicazione in aree di interesse e di finalità specifiche.
*/
import { NgModule } from '@angular/core';

/*
I moduli non ereditano l'accesso a componenti, direttive e pipe dichiarati in altri moduli.
Se, ad esempio, si vuole utilizzare una pipe standard nel componente di un Modulo feature, 
il modulo deve importare CommonModule.
BrowserModule, importato in AppModule, esporta a sua volta CommonModule per il modulo root, 
ma non va importato in nessun modulo oltre il modulo root.
*/
import { CommonModule } from '@angular/common';

// Componenti del modulo feature
import { MyComponent1 } from './my-component1/my.component1';
import { MyChildComponent } from "./my-component1/my-child/my-child.component";
// Service e pipe custom del modulo feature
import { MyService } from './my.service';

import { MySharedModule } from '../my-shared/my-shared.module';

@NgModule({
    declarations: [
        MyComponent1,
        MyChildComponent,
    ],
    imports: [
        CommonModule,
        // Importando il modulo importa anche Direttive custom e Pipe custom
        MySharedModule
    ],
    exports: [
        // Esporta Componenti, Pipe custom e Direttive custom rendendoli disponibili per l'intera applicazione
        MyComponent1
    ],
    providers: [
       MyService
    ],
})

// Esporta il modulo in modo che sia importabile dal modulo root
export class MyFeatureModule1 { }
