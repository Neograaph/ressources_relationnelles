import { Component, OnInit } from '@angular/core';
import { RessourcesService } from 'src/app/services/ressource.service';
import { UtilisateurService } from 'src/app/services/utilisateur.service';
import { Utilisateur } from 'src/app/Models/Utilisateur.model';
import { Ressource } from 'src/app/Models/Ressource.model';
import { FiltreRechercheService } from 'src/app/services/filtre-recherche.service';

@Component({
  selector: 'app-bloc-ressources',
  templateUrl: './bloc-ressources.component.html',
  styleUrls: ['./bloc-ressources.component.css'],
})
export class BlocRessourcesComponent implements OnInit {
  utilisateur?: Utilisateur;
  ressources?: Ressource[];
  filteredResources?: Ressource[];
  nombreRessourcesAAfficher = 10;

  constructor(
    private ressourcesService: RessourcesService,
    private utilisateurService: UtilisateurService,
    private filtreService: FiltreRechercheService
  ) {}

  ngOnInit(): void {
    this.filtreService.filterChange$.subscribe((filter: any) => {
      this.filterResources(filter);
    });

    this.utilisateurService.getUtilisateur().subscribe(
      (utilisateur: Utilisateur | null) => {
        if (utilisateur !== null) {
          this.utilisateur = utilisateur;
        }
      },
      (error) => {
        console.error(
          "Une erreur s'est produite lors de la récupération de l'utilisateur :",
          error
        );
      }
    );

    this.ressourcesService.getRessources().subscribe(
      (ressources: Ressource[]) => {
        this.ressources = ressources;
        this.filterResources(null); // Appliquer le filtre initial
      },
      (error) => {
        console.error(
          "Une erreur s'est produite lors de la récupération des ressources :",
          error
        );
      }
    );
  }

  filterResources(filter: any): void {
    // Votre logique de filtrage actuelle ici

    // Réinitialiser les ressources affichées
    this.filteredResources = this.ressources?.slice(0, this.nombreRessourcesAAfficher);
  }

  onScroll(): void {
    this.nombreRessourcesAAfficher += 10; // Augmenter le nombre de ressources à afficher à chaque défilement
    this.filterResources(null); // Appliquer le filtre avec le nouveau nombre de ressources à afficher
  }
}
