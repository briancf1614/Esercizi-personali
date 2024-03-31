import { TestBed } from '@angular/core/testing';
import { CanActivateFn } from '@angular/router';

import { myDeActivateGuard } from './my-de-activate.guard';

describe('myDeActivateGuard', () => {
  const executeGuard: CanActivateFn = (...guardParameters) => 
      TestBed.runInInjectionContext(() => myDeActivateGuard(...guardParameters));

  beforeEach(() => {
    TestBed.configureTestingModule({});
  });

  it('should be created', () => {
    expect(executeGuard).toBeTruthy();
  });
});
