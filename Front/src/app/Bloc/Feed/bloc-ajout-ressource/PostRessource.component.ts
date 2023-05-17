import { Component, OnInit } from '@angular/core';
import { ActionsTypeService } from 'src/app/services/actions-type.service';
import { ToastrService } from 'ngx-toastr';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Ressource } from 'src/app/Models/Ressource.model';

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
    private formBuilder: FormBuilder
  ) {
    this.createForm();
  }

  Ressource?: Ressource;
  ngOnInit(): void {
    // this.actiontype.getActionType().subscribe((response: any) => {
    //   console.log(response)
    // });
  }
  createForm() {
    // j'ai mis des valeurs par défaut ici pour les tests pour éviter de remplir le formulaire à chaque fois
    // console.log('test');
    this.ajoutRessourceForm = this.formBuilder.group({
      titre: ['', Validators.required],
      description: ['', [Validators.required]],
    });
  }
  publierRessource() {
    if (this.ajoutRessourceForm.valid) {
      const formData = this.ajoutRessourceForm.value;
      console.log(formData);
      // Envoyer les données du formulaire à l'API ou effectuer toute autre action requise
      // par exemple, vous pouvez utiliser this.actiontype pour appeler une méthode de votre service

      // Afficher un message de succès

      // Réinitialiser le formulaire après avoir envoyé les données
      // this.ajoutRessourceForm.reset();
    } else {
      // Afficher un message d'erreur si le formulaire est invalide
    }
  }
}
