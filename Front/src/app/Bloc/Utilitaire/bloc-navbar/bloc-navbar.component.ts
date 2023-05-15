import { Component, OnInit } from '@angular/core';
import { ActionsTypeService } from 'src/app/services/actions-type.service';
import { HttpClient } from '@angular/common/http';
import { catchError } from 'rxjs/operators';
import { ResolveEnd, Router } from '@angular/router';

@Component({
  selector: 'navbar',
  templateUrl: './bloc-navbar.component.html',
  styleUrls: ['./bloc-navbar.component.css'],
})
export class NavbarComponent implements OnInit {
  utilisateurs: any;
  resultatPost: any;
 currentRoute? : string; // Récupère l'URL de la route actuelle
 isMenuOpen = false;


  navbarClass: string = "bg-bleufonce"; // bleufonce valeur par défaut

  constructor(
    public actiontype: ActionsTypeService,
    private http: HttpClient,
    private router : Router
  ) {

  }

  ngOnInit(): void {
    this.router.events.subscribe((routerData) => {
      if(routerData instanceof ResolveEnd){
          this.currentRoute = routerData.url;
          if (this.currentRoute === '/') {
            console.log(this.currentRoute)
            this.navbarClass = 'bg-noir'; // Applique la classe CSS pour la navbar noire
          } else if (this.currentRoute === '/connexion' || this.currentRoute === '/inscription' ) {
            this.navbarClass = 'hidden'; // Applique la classe CSS pour rendre la navbar invisible
          }
        }
    })
  }
  toggleMenu() {
    this.isMenuOpen = !this.isMenuOpen;
  }


}
