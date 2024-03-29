import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http'

// Modulo di routing
import { AppRoutingModule } from './app-routing.module';

// Componenti
import { AppComponent } from './app.component';

import { UnoComponent } from './uno/uno.component';
import { DueComponent } from './due/due.component';
import { TreComponent } from './tre/tre.component';
import { My404Component } from './my404/my404.component';
import { TreUnoComponent } from './tre/tre-uno/tre-uno.component';
import { TreDueComponent } from './tre/tre-due/tre-due.component';

@NgModule({
    declarations: [
        AppComponent,
        UnoComponent,
        DueComponent,
        TreComponent,
        My404Component,
        TreUnoComponent,
        TreDueComponent
    ],
    imports: [
        BrowserModule,
        HttpClientModule,
        AppRoutingModule        
    ],
    providers: [],
    bootstrap: [AppComponent]
})
export class AppModule { }
