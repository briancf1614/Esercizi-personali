import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ProfileComponent } from './profile/profile.component';
import { FormsModule } from '@angular/forms';
import { ProfileRoutingModule } from './profile/profile-routing.module';
import { ProfileService } from './profile.service';



@NgModule({
  declarations: [
    ProfileComponent
  ],
  imports: [
    CommonModule,
    FormsModule,
    ProfileRoutingModule
  ],
  providers:[ProfileService]
})
export class ProfileModule { }
