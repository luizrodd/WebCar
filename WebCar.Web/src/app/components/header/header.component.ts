import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css'],
  standalone: true,
  imports: [FormsModule, CommonModule]
})
export class HeaderComponent {
  searchQuery: string = '';
  isMobileMenuOpen: boolean = false;

  constructor(private router: Router) {}

  searchCars() {
    if (this.searchQuery.trim()) {
      // Redirect to the search results page
      this.router.navigate(['/search'], { queryParams: { query: this.searchQuery } });
    }
  }

  toggleMobileMenu() {
    this.isMobileMenuOpen = !this.isMobileMenuOpen;
  }
}
