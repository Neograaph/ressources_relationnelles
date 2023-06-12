import { Component } from '@angular/core';
import { RessourcesService } from 'src/app/services/ressource.service';
import { UtilisateurService } from 'src/app/services/utilisateur.service';
import { Utilisateur } from 'src/app/Models/Utilisateur.model';
import { Ressource } from 'src/app/Models/Ressource.model';

@Component({
  selector: 'app-bloc-ressources',
  templateUrl: './bloc-ressources.component.html',
  styleUrls: ['./bloc-ressources.component.css'],
})
export class BlocRessourcesComponent {
  utilisateur?: Utilisateur;
  ressources?: Ressource[];
  name: string = 'neograph';

  constructor(
    private RessourcesService: RessourcesService,
    private utilisateurService: UtilisateurService
  ) {}

  ngOnInit(): void {
    this.utilisateurService.getUtilisateur().subscribe(
      (utilisateur: Utilisateur | null) => {
        if (utilisateur !== null) {
          this.utilisateur = utilisateur;
          console.log(this.utilisateur);
        }
      },
      (error) => {
        console.error(
          "Une erreur s'est produite lors de la récupération de l'utilisateur :",
          error
        );
      }
    );
    this.RessourcesService.getRessources().subscribe(
      (ressources: Ressource[]) => {
        this.ressources = ressources;
        console.log(this.ressources);
        // Autres actions à effectuer avec les ressources
      },
      (error) => {
        console.error(
          "Une erreur s'est produite lors de la récupération des ressources :",
          error
        );
      }
    );
  }
}
