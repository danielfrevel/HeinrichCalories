import { MealService } from 'src/app/services/meal.service';
import { Component, OnInit, ViewChild } from '@angular/core';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css'],
})
export class DashboardComponent implements OnInit {
  constructor(public mealService: MealService) {}

  ngOnInit(): void {
    this.mealService.createSession();
  }
  showKey: boolean = false;

  shareSession(): void {
    this.showKey = true;
  }

  showEnterCode: boolean = false;

  enterCode() {
    this.showEnterCode = true;
  }

  boxValue = '';
  zundung(guid: string) {
    this.mealService.getMeals(guid);
  }
}
