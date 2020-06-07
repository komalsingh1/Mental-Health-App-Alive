import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { NopermissionsComponent } from './nopermissions.component';

describe('NopermissionsComponent', () => {
  let component: NopermissionsComponent;
  let fixture: ComponentFixture<NopermissionsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ NopermissionsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(NopermissionsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
