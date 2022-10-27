import { MealService } from './../../../services/meal.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'search-meal',
  templateUrl: './search-meal.component.html',
  styleUrls: ['./search-meal.component.css'],
})
export class SearchMealComponent implements OnInit {
  constructor(public mealService: MealService) {}

  ngOnInit(): void {}
}
