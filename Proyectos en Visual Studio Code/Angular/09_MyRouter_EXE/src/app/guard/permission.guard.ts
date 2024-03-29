import { inject } from '@angular/core';
import { CanMatchFn, Router } from '@angular/router';
import { GlobalService } from '../global.service';

export const permissionGuard: CanMatchFn = (route, segments) => {
  const globalService = inject(GlobalService);
  const router = inject(Router);
  if(globalService.logged.log == "Si"){
    return true;
  }else{
    window.alert("devi loggarti");
    router.navigate(["login"])
    return false;
  }
  
};
