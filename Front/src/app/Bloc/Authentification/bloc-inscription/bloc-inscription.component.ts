import { Component } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';

@Component({
  selector: 'app-bloc-inscription',
  templateUrl: './bloc-inscription.component.html',
  styleUrls: ['./bloc-inscription.component.css']
})
export class BlocInscriptionComponent {
  inscriptionForm!: FormGroup;

  constructor(private formBuilder: FormBuilder) {
    this.createForm();
  }

  createForm() {
    this.inscriptionForm = this.formBuilder.group({
      nom: ['', Validators.required],
      email: ['', [Validators.required, Validators.email]],
      password: ['', [Validators.required, Validators.minLength(6)]],
    });
  }

  submitForm() {
    if (this.inscriptionForm.valid) {
      // Traitez les données d'inscription ici, par exemple, appelez un service pour envoyer les données au serveur.
      console.log(this.inscriptionForm.value);
    } else {
      // Affichez des messages d'erreur ou effectuez d'autres actions appropriées si le formulaire n'est pas valide.
      console.log('Le formulaire d\'inscription est invalide.');
    }
  }
}
