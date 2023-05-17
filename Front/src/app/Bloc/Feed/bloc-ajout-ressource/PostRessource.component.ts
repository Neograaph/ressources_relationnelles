import { Component, OnInit } from '@angular/core';
import { ActionsTypeService } from 'src/app/services/actions-type.service';
import { ToastrService } from 'ngx-toastr';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Ressource } from 'src/app/Models/Ressource.model';
import { NotificationsService } from 'src/app/services/notifications.service';
import { RessourcesService } from '../../../services/ressource.service';

@Component({
  selector: 'app-PostRessource',
  templateUrl: './PostRessource.component.html',
  styleUrls: ['./PostRessource.component.css'],
  providers: [ToastrService],
})
export class PostRessourceComponent implements OnInit {
  ajoutRessourceForm!: FormGroup;

  constructor(
    public actiontype: ActionsTypeService,
    private formBuilder: FormBuilder,
    private NotificationsService: NotificationsService,
    private RessourcesService: RessourcesService
  ) {
    this.createForm();
  }

  // Ressource?: Ressource;
  ngOnInit(): void {}
  createForm() {
    this.ajoutRessourceForm = this.formBuilder.group({
      titre: ['montitredemo', Validators.required],
      contenu: ['hellolemonde', [Validators.required]],
    });
  }
  publierRessource() {
    if (this.ajoutRessourceForm.valid) {
      const formData: Ressource = this.ajoutRessourceForm.value;
      formData.dateCreation = new Date();
      formData.valider = true;
      formData.utilisateurId = 1;
      formData.visibiliteLibelle = 'Public';
      formData.categorieLibelle = 'test';

      this.NotificationsService.showSuccess('Succès', 'Ressource ajoutée');
      console.log(formData);
      this.RessourcesService.createRessource(formData).subscribe();
      this.ajoutRessourceForm.reset();
    } else {
      this.NotificationsService.showError(
        'Erreur',
        'Veuillez remplir tous les champs'
      );
    }
  }
}
