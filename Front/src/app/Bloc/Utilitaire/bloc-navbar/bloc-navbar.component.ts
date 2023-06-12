import { Component, OnInit } from '@angular/core';
import { ActionsTypeService } from 'src/app/services/actions-type.service';
import { HttpClient } from '@angular/common/http';
import { ResolveEnd, Router } from '@angular/router';
import { UtilisateurService } from 'src/app/services/utilisateur.service';
import { Utilisateur } from 'src/app/Models/Utilisateur.model';

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
    private router : Router,
    private utilisateurService : UtilisateurService
  ) {

  }
  utilisateur?: Utilisateur ;

  // Ne fonctionne pas
  // ngOnChanges(): void {
  //   this.router.events.subscribe((routerData) => {
  //     if(routerData instanceof ResolveEnd){
  //         this.currentRoute = routerData.url;
  //         if (this.currentRoute === '/') {
  //           console.log(this.currentRoute)
  //           this.navbarClass = 'bg-noir'; // Applique la classe CSS pour la navbar noire
  //         } else if (this.currentRoute === '/connexion' || this.currentRoute === '/inscription' ) {
  //           this.navbarClass = 'hidden'; // Applique la classe CSS pour rendre la navbar invisible
  //         }
  //       }
  //   })
  // }
  ngOnInit(): void {
    this.utilisateurService.getUtilisateur().subscribe(
      (utilisateur: Utilisateur | null) => {
        if (utilisateur !== null) {
          this.utilisateur = utilisateur;
        }
      },
      (error) => {
        console.error("Une erreur s'est produite lors de la récupération de l'utilisateur :", error);
      }
    );

    this.router.events.subscribe((routerData) => {
      if(routerData instanceof ResolveEnd){
          this.currentRoute = routerData.url;
          // console.log(this.currentRoute)
          if (this.currentRoute === '/') {
            // console.log(this.currentRoute)
            this.navbarClass = 'bg-noir'; // Applique la classe CSS pour la navbar noire
          } else if (this.currentRoute === '/connexion' || this.currentRoute === '/inscription' ) {
            this.navbarClass = 'hidden'; // Applique la classe CSS pour rendre la navbar invisible
          }else {
            this.navbarClass = "bg-bleufonce";
          }
        }
    })
  }
  toggleMenu() {
    this.isMenuOpen = !this.isMenuOpen;
  }


}
