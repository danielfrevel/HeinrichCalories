import {
  Component,
  Input,
  OnChanges,
  OnInit,
  SimpleChanges,
} from '@angular/core';
import { MealDto } from 'src/app/core/Swagger';
import { MealService } from 'src/app/services/meal.service';

@Component({
  selector: 'meal-item',
  templateUrl: './meal-item.component.html',
  styleUrls: ['./meal-item.component.css'],
})
export class MealItemComponent implements OnInit {
  @Input() meal?: MealDto;
  @Input() enableAdding?: boolean;

  constructor(public mealService: MealService) {}

  ngOnInit(): void {}

  addMealEvent() {
    this.mealService.addMeal(this.meal as MealDto);
  }
}
