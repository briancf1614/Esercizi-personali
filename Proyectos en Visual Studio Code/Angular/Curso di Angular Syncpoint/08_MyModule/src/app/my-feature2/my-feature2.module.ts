import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MySharedModule } from '../my-shared/my-shared.module';

import { MyComponent2 } from './my-component2/my-component2.component';

@NgModule({
    declarations: [
        MyComponent2
    ],
    imports: [
        CommonModule,
        // Importando il modulo importa anche Direttive custom e Pipe custom
        MySharedModule
    ],
    exports: [
        MyComponent2
    ],
})
export class MyFeatureModule2 { }
