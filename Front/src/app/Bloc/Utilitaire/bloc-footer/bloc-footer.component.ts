import { OnInit } from '@angular/core';
import { Component } from '@angular/core';
import { ResolveEnd, Router } from '@angular/router';
import { AuthService } from 'src/app/services/auth.service';

@Component({
  selector: 'app-bloc-footer',
  templateUrl: './bloc-footer.component.html',
  styleUrls: ['./bloc-footer.component.css'],
})
export class BlocFooterComponent implements OnInit {
  currentRoute?: string; // Récupère l'URL de la route actuelle

  constructor(private router: Router, private AuthService: AuthService) {}
  footerClass: string = ''; // bleufonce valeur par défaut

  ngOnInit(): void {
    this.router.events.subscribe((routerData) => {
      if (routerData instanceof ResolveEnd) {
        this.currentRoute = routerData.url;
        // console.log(this.currentRoute)
        // if (this.currentRoute === '/') {
        //   // console.log(this.currentRoute)
        //   this.navbarClass = 'bg-noir'; // Applique la classe CSS pour la navbar noire
        // } else3
        if (
          this.currentRoute === '/connexion' ||
          this.currentRoute === '/inscription'
        ) {
          this.footerClass = 'absolute bottom-0 text-blanc w-full bg-transparent';
        } else if (this.currentRoute === '/accueil') {
          this.footerClass = 'bg-transparent';
        } else {
          this.footerClass = 'bg-transparent';
        }
      }
    });
  }
  removeToken(): void {
    this.AuthService.removeToken();
  }
}
