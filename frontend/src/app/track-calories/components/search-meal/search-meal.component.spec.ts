import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SearchMealComponent } from './search-meal.component';

describe('SearchMealComponent', () => {
  let component: SearchMealComponent;
  let fixture: ComponentFixture<SearchMealComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SearchMealComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(SearchMealComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
