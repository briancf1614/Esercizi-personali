import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

// Modulo form
import { FormsModule } from '@angular/forms';

// Components
import { AppComponent } from './app.component';
import { ParentComponent } from './parent-component/parent.component';
import { ChildComponent } from './parent-component/child-component/child.component';

@NgModule({
    declarations: [
        AppComponent,
        ParentComponent,
        ChildComponent
    ],
    imports: [
        BrowserModule,
        FormsModule
    ],
    providers: [],
    bootstrap: [AppComponent]
})
export class AppModule { }
