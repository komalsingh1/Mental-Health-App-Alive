import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { OppurtunitiesComponent } from './oppurtunities.component';

describe('OppurtunitiesComponent', () => {
  let component: OppurtunitiesComponent;
  let fixture: ComponentFixture<OppurtunitiesComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ OppurtunitiesComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(OppurtunitiesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
