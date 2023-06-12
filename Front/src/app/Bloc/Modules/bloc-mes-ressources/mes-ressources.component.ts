import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Ressource } from 'src/app/Models/Ressource.model';
import { NotificationsService } from 'src/app/services/notifications.service';
import { RessourcesService } from '../../../services/ressource.service';
import { RefreshService } from 'src/app/services/refresh-service.service';
import { Utilisateur } from 'src/app/Models/Utilisateur.model';
import { UtilisateurService } from 'src/app/services/utilisateur.service';

@Component({
  selector: 'app-mes-ressources',
  templateUrl: './mes-ressources.component.html',
  styleUrls: ['./mes-ressources.component.css'],
  providers: [ToastrService],
})
export class MesRessourcesComponent implements OnInit {
  ressource!: Ressource;
  utilisateur!: Utilisateur;
  Ressources: Array<Ressource> = [];

  constructor(
    private NotificationsService: NotificationsService,
    private RessourcesService: RessourcesService,
    private refreshService: RefreshService,
    private utilisateurService: UtilisateurService
  ) {}

  ngOnInit(): void {
    this.utilisateurService.getUtilisateur().subscribe(
      (utilisateur: Utilisateur | null) => {
        if (utilisateur !== null) {
          this.utilisateur = utilisateur;
          this.getRessources(this.utilisateur.utilisateurId);
        }
      },
      (error) => {
        console.error("Une erreur s'est produite lors de la récupération de l'utilisateur :", error);
      }
    );

    this.refreshService.refresh$.subscribe(() => {
      this.getRessources(this.utilisateur.utilisateurId);
    });
  }

  getRessources(id: number) {
    this.RessourcesService.getRessourcesUtilisateur(id).subscribe((data) => {
   // this.RessourcesService.getRessources().subscribe((data) => {
      if (Array.isArray(data)) {
        this.Ressources = data;

        if (this.Ressources.length >= 2) {
          this.Ressources = this.sortRessourcesByDate(this.Ressources);
        }
      }
    });
  }

  sortRessourcesByDate(ressources: Ressource[]): Ressource[] {
    return ressources.sort((a, b) => {
      return (
        new Date(a.dateCreation).getTime() - new Date(b.dateCreation).getTime()
      );
    });
  }
}
