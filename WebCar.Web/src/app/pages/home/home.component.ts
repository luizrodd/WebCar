import { Component } from '@angular/core';
import { HeaderComponent } from "../../components/header/header.component";
import { Post } from '../../components/card-car/car.interface';
import { CardCarComponent } from '../../components/card-car/card-car.component';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-home',
  standalone: true,
  imports: [HeaderComponent, CardCarComponent, CommonModule],
  templateUrl: './home.component.html',
  styleUrl: './home.component.css'
})
export class HomeComponent {
  cars: Post[] = [
    {
      id: '10',
      image: ['https://images.pexels.com/photos/2526128/pexels-photo-2526128.jpeg?auto=compress&cs=tinysrgb&dpr=1&w=500', 'car1-side.jpg', 'car1-interior.jpg'],
      price: 41900,
      brand: 'Fiat',
      model: 'Palio',
      version: 'Original',
      typeOfEngine: '1.0 Flex',
      yearOfProduction: 2007,
      yearOfManufacture: 2006,
      acceptTrade: false,
      localization: 'Rio de Janeiro/RJ'
    },
    {
      id: '11',
      image: ['https://images.pexels.com/photos/2526128/pexels-photo-2526128.jpeg?auto=compress&cs=tinysrgb&dpr=1&w=500', 'car2-side.jpg', 'car2-interior.jpg'],
      price: 59900,
      brand: 'Volkswagen',
      model: 'Gol',
      version: 'Turbo',
      typeOfEngine: '1.8 Gasolina',
      yearOfProduction: 1993,
      yearOfManufacture: 1993,
      acceptTrade: true,
      localization: 'São Paulo/SP'
    },
    {
      id: '13',
      image: ['https://images.pexels.com/photos/2526128/pexels-photo-2526128.jpeg?auto=compress&cs=tinysrgb&dpr=1&w=500', 'car3-side.jpg', 'car3-interior.jpg'],
      price: 84900,
      brand: 'BMW',
      model: '325i',
      version: 'Original',
      typeOfEngine: '2.5 Gasolina',
      yearOfProduction: 1994,
      yearOfManufacture: 1994,
      acceptTrade: false,
      localization: 'Curitiba/PR'
    },
    {
      id: '14',
      image: ['https://images.pexels.com/photos/2526128/pexels-photo-2526128.jpeg?auto=compress&cs=tinysrgb&dpr=1&w=500', 'car4-side.jpg', 'car4-interior.jpg'],
      price: 105000,
      brand: 'Toyota',
      model: 'Corolla',
      version: 'GLi',
      typeOfEngine: '2.0 Flex',
      yearOfProduction: 2018,
      yearOfManufacture: 2017,
      acceptTrade: true,
      localization: 'Belo Horizonte/MG'
    },
    {
      id: '12',
      image: ['https://images.pexels.com/photos/2526128/pexels-photo-2526128.jpeg?auto=compress&cs=tinysrgb&dpr=1&w=500', 'car5-side.jpg', 'car5-interior.jpg'],
      price: 132500,
      brand: 'Honda',
      model: 'Civic',
      version: 'Touring',
      typeOfEngine: '1.5 Turbo',
      yearOfProduction: 2020,
      yearOfManufacture: 2019,
      acceptTrade: false,
      localization: 'Porto Alegre/RS'
    }
  ];
}
