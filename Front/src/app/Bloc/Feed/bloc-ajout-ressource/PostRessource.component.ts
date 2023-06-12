import { Component, OnInit } from '@angular/core';
import { ActionsTypeService } from 'src/app/services/actions-type.service';
import { ToastrService } from 'ngx-toastr';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Ressource } from 'src/app/Models/Ressource.model';
import { NotificationsService } from 'src/app/services/notifications.service';
import { RessourcesService } from '../../../services/ressource.service';
import { RefreshService } from 'src/app/services/refresh-service.service';
import { UtilisateurService } from 'src/app/services/utilisateur.service';
import { Utilisateur } from 'src/app/Models/Utilisateur.model';

@Component({
  selector: 'app-PostRessource',
  templateUrl: './PostRessource.component.html',
  styleUrls: ['./PostRessource.component.css'],
  providers: [ToastrService],
})
export class PostRessourceComponent implements OnInit {
  ajoutRessourceForm!: FormGroup;
  utilisateur!: Utilisateur;

  constructor(
    public actiontype: ActionsTypeService,
    private formBuilder: FormBuilder,
    private NotificationsService: NotificationsService,
    private RessourcesService: RessourcesService,
    private refreshService: RefreshService,
    private utilisateurService: UtilisateurService,
  ) {
    this.createForm();
  }
  ressource!: Ressource;
  ngOnInit(): void {
    this.utilisateurService.getUtilisateur().subscribe(
      (utilisateur: Utilisateur | null) => {
        if (utilisateur !== null) {
          this.utilisateur = utilisateur;
        }
      },
      (error) => {
        console.error("Une erreur s'est produite lors de la récupération de l'utilisateur :", error);
      }
    );
  }
  createForm() {
    this.ajoutRessourceForm = this.formBuilder.group({
      titre: ['', Validators.required],
      contenu: ['', [Validators.required]],
    });
  }
  publierRessource() {
    if (this.ajoutRessourceForm.valid) {
      this.ressource = this.ajoutRessourceForm.value;
      this.ressource.dateCreation = new Date();
      this.ressource.valider = true;
      this.ressource.utilisateurId = this.utilisateur.utilisateurId;
      this.ressource.visibiliteLibelle = 'Public';
      this.ressource.categorieLibelle = 'test';

      this.NotificationsService.showSuccess('Succès', 'Ressource ajoutée');
      console.log(this.ressource);
      this.RessourcesService.createRessource(this.ressource).subscribe();
      this.ajoutRessourceForm.reset();
      this.triggerRefresh();
    } else {
      this.NotificationsService.showError(
        'Erreur',
        'Veuillez remplir tous les champs'
      );
    }
  }
  triggerRefresh(): void {
    this.refreshService.triggerRefresh();
  }
}
