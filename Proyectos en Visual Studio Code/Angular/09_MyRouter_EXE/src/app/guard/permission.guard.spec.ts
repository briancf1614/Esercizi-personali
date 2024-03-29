import { TestBed } from '@angular/core/testing';
import { CanMatchFn } from '@angular/router';

import { permissionGuard } from './permission.guard';

describe('permissionGuard', () => {
  const executeGuard: CanMatchFn = (...guardParameters) => 
      TestBed.runInInjectionContext(() => permissionGuard(...guardParameters));

  beforeEach(() => {
    TestBed.configureTestingModule({});
  });

  it('should be created', () => {
    expect(executeGuard).toBeTruthy();
  });
});
