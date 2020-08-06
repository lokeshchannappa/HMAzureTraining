import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CosmosDBComponent } from './cosmos-db.component';

describe('CosmosDBComponent', () => {
  let component: CosmosDBComponent;
  let fixture: ComponentFixture<CosmosDBComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CosmosDBComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CosmosDBComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
