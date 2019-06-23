import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AllCollegesComponent } from './all-colleges.component';

describe('AllCollegesComponent', () => {
  let component: AllCollegesComponent;
  let fixture: ComponentFixture<AllCollegesComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AllCollegesComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AllCollegesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
