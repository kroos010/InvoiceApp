import { TestBed } from '@angular/core/testing';

import { AuthenticationTokenManagerService } from './authentication-token-manager.service';

describe('AuthenticationTokenManagerService', () => {
  let service: AuthenticationTokenManagerService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(AuthenticationTokenManagerService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
