import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { SearchCollegeComponent } from './search-college.component';

describe('SearchCollegeComponent', () => {
  let component: SearchCollegeComponent;
  let fixture: ComponentFixture<SearchCollegeComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ SearchCollegeComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SearchCollegeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
