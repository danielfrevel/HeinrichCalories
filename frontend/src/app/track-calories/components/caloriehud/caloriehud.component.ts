import { MealService } from 'src/app/services/meal.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-caloriehud',
  templateUrl: './caloriehud.component.html',
  styleUrls: ['./caloriehud.component.css'],
})
export class CaloriehudComponent implements OnInit {
  constructor(public mealService: MealService) {}

  ngOnInit(): void {}
}
