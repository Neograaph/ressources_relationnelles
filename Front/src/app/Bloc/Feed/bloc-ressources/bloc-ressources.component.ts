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
        this.filterResources(ressources); // Appliquer le filtre initial
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
    const selectedCategoryId = filter.selectedCategoryId;
    const selectedTypeRessourceId = filter.selectedTypeRessourceId;
    const publicationName = filter.publicationName;
    const author = filter.author;
    const publicationDate = filter.publicationDate;
    // Effectuez le filtrage des ressources en fonction du filtre
    if (this.ressources) {
      this.filteredResources = this.ressources
        .filter((resource) => {
          // Filtre sur la catégorie
          if (
            selectedCategoryId &&
            resource.categorieId !== Number(selectedCategoryId)
          ) {
            return false;
          }

          // Filtre sur le type de ressource
          if (
            selectedTypeRessourceId &&
            resource.typeRessourceId !== Number(selectedTypeRessourceId)
          ) {
            return false;
          }

          // Filtre sur le nom de l'auteur
          if (
            author &&
            resource.utilisateur?.nom?.toLowerCase() !== author.toLowerCase()
          ) {
            return false;
          }

          // Filtre sur le nom de la publication
          if (
            publicationName &&
            !resource.titre
              ?.toLowerCase()
              .includes(publicationName.toLowerCase())
          ) {
            return false;
          }
          // Filtre sur la date de publication
          if (publicationDate) {
            const resourceDate = new Date(resource.dateCreation);
            resourceDate.setHours(0, 0, 0, 0); // Définir l'heure à 00:00:00:000
            const filterDate = new Date(publicationDate);
            filterDate.setHours(0, 0, 0, 0); // Définir l'heure à 00:00:00:000

            if (resourceDate.getTime() !== filterDate.getTime()) {
              return false;
            }
          }

          return true;
        })
        .reverse(); // Inverser l'ordre des ressources
    }
  }

  onScroll(): void {
    this.nombreRessourcesAAfficher += 10; // Augmenter le nombre de ressources à afficher à chaque défilement
    this.filterResources(null); // Appliquer le filtre avec le nouveau nombre de ressources à afficher
  }
}
