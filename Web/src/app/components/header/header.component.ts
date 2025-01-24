import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { MatSidenavModule } from '@angular/material/sidenav';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css'],
  standalone: true,
  imports: [FormsModule, CommonModule, MatSidenavModule]
})
export class HeaderComponent {
  searchQuery: string = '';
  isMobileMenuOpen: boolean = false;
  showFiller = false;
  isExpanded = false;
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
