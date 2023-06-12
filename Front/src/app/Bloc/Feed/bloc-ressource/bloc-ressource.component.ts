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
  utilisateur?: Utilisateur;
  constructor(
    private utilisateurService: UtilisateurService,
    private aimerService: AimerService
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
    const aimer: Aimer | any = {
      RessourceId: this.data.ressourceId,
      DateAimer: new Date(),
      UtilisateurId: this.utilisateur?.utilisateurId || 0,
    };

    this.aimerService.createAimer(aimer).subscribe(
      (response: Aimer) => {
        // La création de l'Aimer a réussi
        console.log('Aimer créé avec succès', response);
      },
      (error) => {
        console.error("Erreur lors de la création de l'Aimer :", error);
      }
    );
  }
}
