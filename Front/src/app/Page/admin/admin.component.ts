'@angular/core';
import { Router } from '@angular/router';
import { Utilisateur } from 'src/app/Models/Utilisateur.model';
import { AuthService } from 'src/app/services/auth.service';
import { UtilisateurService } from 'src/app/services/utilisateur.service';

import { RessourcesService } from 'src/app/services/ressource.service';
import { Ressource } from 'src/app/Models/Ressource.model';
import { Component, OnInit } from '@angular/core';
@Component({
  selector: 'app-admin',
  templateUrl: './admin.component.html',
  styleUrls: ['./admin.component.css']
})
export class AdminComponent implements OnInit {
  utilisateur!: Utilisateur;
  ressourcesParType: Ressource[] = [];

  constructor(
    private router : Router,
    private utilisateurService : UtilisateurService,
    private auth : AuthService,
    private ressourceService : RessourcesService
  ) {

  }
  ngOnInit(): void {
    this.utilisateurService.getUtilisateur().subscribe(
      (utilisateur: Utilisateur | null) => {
        if (utilisateur !== null) {
          this.utilisateur = utilisateur;
          if (this.utilisateur.role != "Administrateur") {
            this.router.navigate(['/accueil']);
          }
        } else {
          this.router.navigate(['/accueil']);
        }
      },
      (error) => {
        this.router.navigate(['/accueil']);
        console.error("Une erreur s'est produite lors de la récupération de l'utilisateur :", error);
      }
    );
    this.ressourceService.getRessources().subscribe(data=> {
      this.ressourcesParType = data;

    });

  }
}
