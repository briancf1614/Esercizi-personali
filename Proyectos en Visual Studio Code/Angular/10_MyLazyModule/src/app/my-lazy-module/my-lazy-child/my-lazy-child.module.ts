import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MyLazyGrandChildComponent } from './my-lazy-grand-child/my-lazy-grand-child.component';
import { LazyChildRoutingModule } from './lazy-child-routing.module';



@NgModule({
  declarations: [
    MyLazyGrandChildComponent
  ],
  imports: [
    CommonModule,
    LazyChildRoutingModule
  ]
})
export class MyLazyChildModule { }
