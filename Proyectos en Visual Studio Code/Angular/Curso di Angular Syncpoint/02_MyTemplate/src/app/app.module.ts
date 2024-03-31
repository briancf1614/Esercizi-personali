import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
// Modulo Forms (fornisce, tra l'altro, la direttiva ngModel per il two-way data binding)
import { FormsModule } from '@angular/forms';

// Componente
import { AppComponent } from './app.component';

@NgModule({
    declarations: [
        AppComponent
    ],
    imports: [
        BrowserModule,
        FormsModule
    ],
    providers: [],
    bootstrap: [AppComponent]
})

export class AppModule { }
