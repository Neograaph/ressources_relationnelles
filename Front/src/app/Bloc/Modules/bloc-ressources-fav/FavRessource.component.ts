import { Component, OnInit } from '@angular/core';
import { ActionsTypeService } from 'src/app/services/actions-type.service';
import { Utilisateur } from 'src/app/Models/Utilisateur.model';
import { UtilisateurService } from 'src/app/services/utilisateur.service';
import { AimerService } from 'src/app/services/favressource.service';
import { Aimer } from 'src/app/Models/Aimer.model';

@Component({
  selector: 'app-FavRessource',
  templateUrl: './FavRessource.component.html',
  styleUrls: ['./FavRessource.component.css'],
})
export class FavRessourceComponent implements OnInit {
  utilisateur!: Utilisateur;
  FavRessource: Array<Aimer> = [];
  constructor(
    private utilisateurService: UtilisateurService,
    private FavRessourceService: AimerService
  ) {}

  ngOnInit(): void {
    this.utilisateurService.getUtilisateur().subscribe(
      (utilisateur: Utilisateur | null) => {
        if (utilisateur !== null) {
          this.utilisateur = utilisateur;
          this.getFavRessources(this.utilisateur.utilisateurId);
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
  getFavRessources(id: number) {
    this.FavRessourceService.getAimerById(id).subscribe((data) => {
      if (Array.isArray(data)) {
        this.FavRessource = data;
        console.log(this.FavRessource);
      }
    });
  }

  data = [
    {
      title: 'Ressources 1',
      date: '15/05/2023',
    },
    {
      title: 'Produit 2',
      date: '15/05/2023',
    },
    {
      title: 'Produit 3',
      date: '15/05/2023',
    },
    {
      title: 'Produit 4',
      date: '15/05/2023',
    },
    {
      title: 'Produit 5',
      date: '15/05/2023',
    },
  ];
}
