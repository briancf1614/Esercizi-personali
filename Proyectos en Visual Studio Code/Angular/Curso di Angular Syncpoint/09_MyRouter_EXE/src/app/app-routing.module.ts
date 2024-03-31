import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './login/login/login.component';
import { permissionGuard } from './guard/permission.guard';







const routes: Routes = [
  { path: 'login', component: LoginComponent, title: 'Componente Uno' },


  { path: '', redirectTo: 'uno', pathMatch: 'full' },

  { path: 'network', 
      loadChildren: () => import('./network/network.module').then(m => m.NetworkModule), canMatch: [permissionGuard]
  },
  { path: 'profile', 
      loadChildren: () => import('./profile/profile.module').then(m => m.ProfileModule), canMatch: [permissionGuard]
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes,{
    bindToComponentInputs:true
  })],
  exports: [RouterModule]
})
export class AppRoutingModule { }
