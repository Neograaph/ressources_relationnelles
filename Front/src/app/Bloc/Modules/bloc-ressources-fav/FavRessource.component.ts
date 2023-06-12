import { Component, OnInit } from '@angular/core';
import { ActionsTypeService } from 'src/app/services/actions-type.service';
import { Utilisateur } from 'src/app/Models/Utilisateur.model';
import { UtilisateurService } from 'src/app/services/utilisateur.service';

@Component({
  selector: 'app-FavRessource',
  templateUrl: './FavRessource.component.html',
  styleUrls: ['./FavRessource.component.css'],
})
export class FavRessourceComponent implements OnInit {
  utilisateur!: Utilisateur;

  constructor(private utilisateurService: UtilisateurService) {}

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
  getFavRessources(id: number) {}

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
