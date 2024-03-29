import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';

// Le pipe builtin da usare via model vanno importate come Service
import { UpperCasePipe } from '@angular/common';

// Custom Pipes
import { MyPipe } from './my.pipe';
import { MyTranslatorPipe } from './my-translator.pipe';

@NgModule({
    declarations: [
        AppComponent,
        MyPipe,
        MyTranslatorPipe
    ],
    imports: [
        BrowserModule
    ],
    providers: [UpperCasePipe],
    bootstrap: [AppComponent]
})
export class AppModule { }
