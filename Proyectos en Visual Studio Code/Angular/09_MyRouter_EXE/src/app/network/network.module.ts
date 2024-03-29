import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NetworkComponent } from './network/network.component';
import { NetworkRoutingModule } from './network/network-routing.module';
import { NetworkService } from './network.service';



@NgModule({
  declarations: [
    NetworkComponent
  ],
  imports: [
    CommonModule,
    NetworkRoutingModule
  ],
  providers:[NetworkService]
})
export class NetworkModule { }
