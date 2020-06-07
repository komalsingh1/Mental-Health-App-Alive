import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { StressmgmtComponent } from './stressmgmt.component';

describe('StressmgmtComponent', () => {
  let component: StressmgmtComponent;
  let fixture: ComponentFixture<StressmgmtComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ StressmgmtComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(StressmgmtComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
