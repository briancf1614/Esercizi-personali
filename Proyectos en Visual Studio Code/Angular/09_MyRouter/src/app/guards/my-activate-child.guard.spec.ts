import { TestBed } from '@angular/core/testing';
import { CanActivateFn } from '@angular/router';

import { myActivateChildGuard } from './my-activate-child.guard';

describe('myActivateChildGuard', () => {
  const executeGuard: CanActivateFn = (...guardParameters) => 
      TestBed.runInInjectionContext(() => myActivateChildGuard(...guardParameters));

  beforeEach(() => {
    TestBed.configureTestingModule({});
  });

  it('should be created', () => {
    expect(executeGuard).toBeTruthy();
  });
});
