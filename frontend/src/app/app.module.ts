import { Client } from 'src/app/core/Swagger';
import { TrackCaloriesModule } from './track-calories/track-calories.module';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';

@NgModule({
  declarations: [AppComponent],
  imports: [BrowserModule, AppRoutingModule, TrackCaloriesModule],
  providers: [Client],
  bootstrap: [AppComponent],
})
export class AppModule {}
