import { Injectable } from '@angular/core';
import { BehaviorSubject, map, Observable, take } from 'rxjs';
import { Client, MealDto } from 'src/app/core/Swagger';

@Injectable({
  providedIn: 'root',
})
export class MealService {
  private _meals$ = new BehaviorSubject<MealDto[]>([]);
  meals$ = this._meals$.asObservable();

  private _foundMeals$ = new BehaviorSubject<MealDto[]>([]);
  foundMeals$ = this._foundMeals$.asObservable();

  private _key$ = new BehaviorSubject<string>('');
  public key$ = this._key$.asObservable().pipe(
    map((p) => {
      this.getMeals(p);
      return p;
    })
  );

  public currentCalories$: Observable<number> = this.meals$.pipe(
    map((meals) => {
      let result = 0;
      meals.map((meal) => {
        result += meal.calories ?? 0;
      });

      return result;
    })
  );

  width$ = this.currentCalories$.pipe(
    map((p) => {
      let currentCals = p;
      let calsGoal = 2500;
      return (currentCals / calsGoal) * 100;
    })
  );

  constructor(private client: Client) {
    this.createSession();
  }

  createSession() {
    this.client.createSession().subscribe((p) => {
      this._key$.next(p.guid as any);
    });
  }

  searchMeals(searchExpr: string) {
    this.client.search(searchExpr).subscribe((foundMeals) => {
      if (!foundMeals) return;
      this._foundMeals$.next(foundMeals);
    });
  }

  addMeal(meal: MealDto) {
    this.key$.pipe(take(1)).subscribe((guid) => {
      this.client.addMeal(guid, meal).subscribe();
      this.getMeals(guid);
    });
  }

  getMeals(inputGuid: string) {
    this.client.allMealsFor(inputGuid).subscribe((p) => {
      this._meals$.next(p);
    });
  }

  /////NSFW/////
  //Programmiergötter vergebt mir für diesen Code 😔

  public currentFat$: Observable<number> = this.meals$.pipe(
    map((meals) => {
      let result = 0;
      meals.map((meal) => {
        result += meal.fats ?? 0;
      });

      return result;
    })
  );
  public currentCarbs$: Observable<number> = this.meals$.pipe(
    map((meals) => {
      let result = 0;
      meals.map((meal) => {
        result += meal.carbs ?? 0;
      });

      return result;
    })
  );
  public currentProtein$: Observable<number> = this.meals$.pipe(
    map((meals) => {
      let result = 0;
      meals.map((meal) => {
        result += meal.prots ?? 0;
      });

      return result;
    })
  );
}
