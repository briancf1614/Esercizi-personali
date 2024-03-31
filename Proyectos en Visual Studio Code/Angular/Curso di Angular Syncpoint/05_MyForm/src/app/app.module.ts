import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

// Modulo per Template forms
import { FormsModule } from '@angular/forms';
// Modulo HttpClient
import { HttpClientModule } from '@angular/common/http';

// Componente
import { AppComponent } from './app.component';

@NgModule({
    declarations: [
        AppComponent
    ],
    imports: [
        BrowserModule,
        FormsModule,
        HttpClientModule
    ],
    providers: [],
    bootstrap: [AppComponent]
})
export class AppModule { }
