import { Routes } from '@angular/router';
import { HomeComponent } from './pages/home/home.component';
import { CarDetailsComponent } from './pages/cars/car-details/car-details.component';

export const routes: Routes = [
  {
    path: '',
    component: HomeComponent
  },
  {
    path: 'detalhes/:id',
    component: CarDetailsComponent
  }
];
