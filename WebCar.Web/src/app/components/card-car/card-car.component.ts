import { Component, Input, OnInit } from '@angular/core';
import { Post } from './car.interface';
import { Router } from '@angular/router';

@Component({
  selector: 'app-card-car',
  standalone: true,
  imports: [],
  templateUrl: './card-car.component.html',
  styleUrl: './card-car.component.css'
})
export class CardCarComponent implements OnInit {
  @Input() car: Post = {
    id: '1',
    price: 0,
    brand: '',
    model: '',
    version: '',
    typeOfEngine: '',
    yearOfProduction: 0,
    yearOfManufacture: 0,
    acceptTrade: false,
    localization: '',
    image: []
  };

  constructor(private router: Router) { }

  ngOnInit(): void {
  }

  navigateToDetails(id: string){
    this.router.navigate([`detalhes/${id}`]);
  }
}
