import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { MyPipe } from './my.pipe';

@NgModule({
    declarations: [
        MyPipe
    ],
    imports: [
        CommonModule
    ],
    // Rende pubblica la pipe
    exports: [
        MyPipe
    ]
})
export class MySharedModule { }
