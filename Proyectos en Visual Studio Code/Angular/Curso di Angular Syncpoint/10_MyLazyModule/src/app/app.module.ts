import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
// Modulo Routing
import { AppRoutingModule } from './app-routing.module';

// Componenti
import { AppComponent } from './app.component';
import { MyComponent } from './my-component/my.component';

@NgModule({
    declarations: [
        AppComponent,
        MyComponent
    ],
    imports: [
        BrowserModule,
        AppRoutingModule
    ],
    providers: [],
    bootstrap: [AppComponent]
})
export class AppModule { }
