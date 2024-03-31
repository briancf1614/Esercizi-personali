import { TestBed } from '@angular/core/testing';
import { CanActivateFn } from '@angular/router';

import { myActivateGuard } from './my-activate.guard';

describe('myActivateGuard', () => {
  const executeGuard: CanActivateFn = (...guardParameters) => 
      TestBed.runInInjectionContext(() => myActivateGuard(...guardParameters));

  beforeEach(() => {
    TestBed.configureTestingModule({});
  });

  it('should be created', () => {
    expect(executeGuard).toBeTruthy();
  });
});
