import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AzureBlobComponent } from './azure-blob.component';

describe('AzureBlobComponent', () => {
  let component: AzureBlobComponent;
  let fixture: ComponentFixture<AzureBlobComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AzureBlobComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AzureBlobComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
