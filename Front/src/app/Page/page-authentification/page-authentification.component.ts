import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-page-authentification',
  templateUrl: './page-authentification.component.html',
  styleUrls: ['./page-authentification.component.css'],
})
export class PageAuthentificationComponent {
  constructor(private router: Router) {}

  // Méthode pour vérifier si la route actuelle correspond à une certaine valeur
  estRoute(route: string): boolean {
    return this.router.url === route;
  }
}
