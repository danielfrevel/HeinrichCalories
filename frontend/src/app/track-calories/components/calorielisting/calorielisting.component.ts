import { MealService } from './../../../services/meal.service';
import { BehaviorSubject } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Router, UrlSerializer } from '@angular/router';
import { Client } from 'src/app/core/Swagger';
@Component({
  selector: 'app-calorielisting',
  templateUrl: './calorielisting.component.html',
  styleUrls: ['./calorielisting.component.css'],
})
export class CalorielistingComponent implements OnInit {
  constructor(
    private router: Router,
    private serializer: UrlSerializer,
    private client: Client,
    public mealService: MealService
  ) {}

  ngOnInit(): void {}

  // constructor(private router: Router, private serializer: UrlSerializer) {
  //   const queryParams = { foo: 'a', bar: 42 };
  //   const tree = router.createUrlTree([], { queryParams });

  //   console.log(serializer.serialize(tree));

  showNewMealSelection = false;
  addNewMeal() {
    this.showNewMealSelection = true;
  }

  createShareUrl(guid: string) {
    const queryParams = { guid: guid };
    const tree = this.router.createUrlTree([], { queryParams });
    return this.serializer.serialize(tree);
  }
}
