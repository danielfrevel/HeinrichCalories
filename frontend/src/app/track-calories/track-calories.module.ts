import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { TrackCaloriesRoutingModule } from './track-calories-routing.module';
import { DashboardComponent } from './pages/dashboard/dashboard.component';
import { CaloriehudComponent } from './components/caloriehud/caloriehud.component';
import { CalorielistingComponent } from './components/calorielisting/calorielisting.component';
import { HttpClientModule } from '@angular/common/http';
import { MealItemComponent } from './components/meal-item/meal-item.component';
import { SearchMealComponent } from './components/search-meal/search-meal.component';
import { FormsModule } from '@angular/forms';

@NgModule({
  declarations: [
    DashboardComponent,
    CaloriehudComponent,
    CalorielistingComponent,
    MealItemComponent,
    SearchMealComponent,
  ],
  imports: [
    CommonModule,
    TrackCaloriesRoutingModule,
    HttpClientModule,
    FormsModule,
  ],
  exports: [DashboardComponent],
})
export class TrackCaloriesModule {}
