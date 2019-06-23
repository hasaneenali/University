import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { UniversitieAddComponent } from './universitie-add.component';

describe('UniversitieAddComponent', () => {
  let component: UniversitieAddComponent;
  let fixture: ComponentFixture<UniversitieAddComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ UniversitieAddComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(UniversitieAddComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
