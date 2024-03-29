import { NgModule } from '@angular/core';
// Moduli Routing
import { Routes, RouterModule } from '@angular/router';

// Componenti
import { UnoComponent } from './uno/uno.component';
import { DueComponent } from './due/due.component';
import { TreComponent } from './tre/tre.component';
import { My404Component } from './my404/my404.component';
// Componenti child
import { TreUnoComponent } from './tre/tre-uno/tre-uno.component';
import { TreDueComponent } from './tre/tre-due/tre-due.component';

// Guards
import { myActivateGuard } from './guards/my-activate.guard';
import { myActivateChildGuard } from './guards/my-activate-child.guard';
import { myDeActivateGuard } from './guards/my-de-activate.guard';


// Routes
const routes: Routes = [
    { path: 'uno', component: UnoComponent, title: 'Componente Uno' },
    { path: 'due', component: DueComponent, title: 'Componente Due' }, 
    // Path con parametri
    { path: 'due/:id', component: DueComponent, title: 'Componente Due + Parametri'},
    // Children Routes     
    { path: 'tre', component: TreComponent, title: 'Componente Tre', 
        canActivate: [myActivateGuard], 
        canActivateChild: [myActivateChildGuard],
        children: [
            // data: consente di passare dati statici
            { path: 'tre-uno', component: TreUnoComponent, title: 'Componente TreUno', data: { mydata1: 'My data 1', mydata2: 'My data 2' } },
            { path: 'tre-due', component: TreDueComponent, title: 'Componente TreDue', canDeactivate: [myDeActivateGuard] },
        ]
    },
    /* Path con redirect
    pathMatch: il router controlla gli elementi URL da sinistra per vedere se l'URL corrisponde a un determinato path
    - prefix: default, match quando l'URL inizia con il percorso indicato come prefisso
    - full: match quando l'intero URL corrisponde, utile quando si reindirizza verso path vuoti
    */
    { path: '', redirectTo: 'uno', pathMatch: 'full' },
    // Path per gli URL non validi
    // In ultima posizione perché corrisponde a tutti gli URL e il router la seleziona solo se nessun'altra route corrisponde prima
    { path: '**', component: My404Component, title: 'Componente 404' }
];

@NgModule({
    /*
    Configurazione del Router
    forRoot() associa l’array di route alla root dell’applicazione.
    Inoltre fornisce il servizio di router stesso: usato solo nel modulo root
    L'analogo metodo forChild() non fornisce tale servizio: usato per i moduli lazy
    */
    imports: [RouterModule.forRoot(
        routes, 
        { 
            // Abilita il binding con gli @input() dei componenti (da Angular 16)
            bindToComponentInputs: true          
        }
    )],
    exports: [RouterModule]
})

export class AppRoutingModule { }
