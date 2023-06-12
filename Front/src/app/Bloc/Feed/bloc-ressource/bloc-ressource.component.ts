import { Component, Input } from '@angular/core';
import { Ressource } from 'src/app/Models/Ressource.model';
import { Utilisateur } from 'src/app/Models/Utilisateur.model';
import { UtilisateurService } from 'src/app/services/utilisateur.service';

@Component({
  selector: 'app-bloc-ressource',
  templateUrl: './bloc-ressource.component.html',
  styleUrls: ['./bloc-ressource.component.css'],
})
export class BlocRessourceComponent {
  @Input() data!: Ressource;
  utilisateur?: Utilisateur;
  constructor(private utilisateurService: UtilisateurService) {}

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
  }
}
