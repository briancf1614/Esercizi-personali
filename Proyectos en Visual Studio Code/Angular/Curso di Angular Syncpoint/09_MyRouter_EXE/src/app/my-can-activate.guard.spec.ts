import { TestBed } from '@angular/core/testing';
import { CanActivateFn } from '@angular/router';

import { myCanActivateGuard } from './my-can-activate.guard';

describe('myCanActivateGuard', () => {
  const executeGuard: CanActivateFn = (...guardParameters) => 
      TestBed.runInInjectionContext(() => myCanActivateGuard(...guardParameters));

  beforeEach(() => {
    TestBed.configureTestingModule({});
  });

  it('should be created', () => {
    expect(executeGuard).toBeTruthy();
  });
});
