import { Component, Input } from '@angular/core';
import { Ressource } from 'src/app/Models/Ressource.model';
import { Utilisateur } from 'src/app/Models/Utilisateur.model';
import { UtilisateurService } from 'src/app/services/utilisateur.service';
import { AimerService } from 'src/app/services/favressource.service';
import { Aimer } from 'src/app/Models/Aimer.model';
@Component({
  selector: 'app-bloc-ressource',
  templateUrl: './bloc-ressource.component.html',
  styleUrls: ['./bloc-ressource.component.css'],
})
export class BlocRessourceComponent {
  @Input() data!: Ressource;
  utilisateur!: Utilisateur;
  isLiked: boolean = false;

  constructor(
    private utilisateurService: UtilisateurService,
    private FavRessourceService: AimerService
  ) {}

  ngOnInit(): void {
    this.utilisateurService.getUtilisateur().subscribe(
      (utilisateur: Utilisateur | null) => {
        if (utilisateur !== null) {
          this.utilisateur = utilisateur;
          // console.log(this.utilisateur);
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
  like() {
    console.log('like');
    this.isLiked = !this.isLiked;
    const ressourceId = this.data.ressourceId; // Supposons que RessourceId est l'identifiant de la ressource actuelle
    const utilisateurId = this.utilisateur.utilisateurId;

    this.FavRessourceService.checkAimerExists(
      utilisateurId,
      ressourceId
    ).subscribe(
      (exists: boolean) => {
        if (!exists) {
          const newAimer: Aimer = {
            ressourceId: ressourceId,
            utilisateurId: utilisateurId,
            dateAimer: new Date(),
          };
          this.FavRessourceService.createAimer(newAimer).subscribe(
            (aimer: Aimer) => {
              console.log('Ressource aimée ajoutée avec succès:', aimer);
              // Effectuez d'autres actions si nécessaire
            },
            (error) => {
              console.error(
                "Une erreur s'est produite lors de l'ajout de la ressource aimée:",
                error
              );
            }
          );
        } else {
          console.log('La ressource est déjà aimée par cet utilisateur.');
          this.FavRessourceService.deleteAimer(
            // utilisateurId,
            ressourceId
          ).subscribe(
            () => {
              console.log('Ressource aimée supprimée avec succès.');
              // Effectuez d'autres actions si nécessaire
            },
            (error) => {
              console.error(
                "Une erreur s'est produite lors de la suppression de la ressource aimée:",
                error
              );
            }
          );
        }
      },
      (error) => {
        console.error(
          "Une erreur s'est produite lors de la vérification de la ressource aimée:",
          error
        );
      }
    );
  }
}
