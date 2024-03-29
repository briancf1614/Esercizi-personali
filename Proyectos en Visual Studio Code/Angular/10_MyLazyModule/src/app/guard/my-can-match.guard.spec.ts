import { TestBed } from '@angular/core/testing';
import { CanActivateFn } from '@angular/router';

import { myCanMatchGuard } from './my-can-match.guard';

describe('myCanMatchGuard', () => {
  const executeGuard: CanActivateFn = (...guardParameters) => 
      TestBed.runInInjectionContext(() => myCanMatchGuard(...guardParameters));

  beforeEach(() => {
    TestBed.configureTestingModule({});
  });

  it('should be created', () => {
    expect(executeGuard).toBeTruthy();
  });
});
