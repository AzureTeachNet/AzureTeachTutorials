import { TestBed } from '@angular/core/testing';

import { AzureAdDemoService } from './azure-ad-demo.service';

describe('AzureAdDemoService', () => {
  let service: AzureAdDemoService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(AzureAdDemoService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
