import { compileNgModule } from '@angular/compiler';
import { Component, EnvironmentInjector, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { AuthService } from 'src/app/services/auth.service';
import { RouterModule } from '@angular/router';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ToastrService } from 'ngx-toastr';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-bloc-connexion',
  templateUrl: './bloc-connexion.component.html',
  styleUrls: ['./bloc-connexion.component.css'],
  providers: [ToastrService],
})
export class BlocConnexionComponent {
  connexionForm!: FormGroup;

  constructor(
    private formBuilder: FormBuilder,
    private AuthService: AuthService,
    private injector: EnvironmentInjector,
    private toastr: ToastrService
  ) {
    this.createForm();
  }
  OnInit(): void {}

  createForm() {
    // j'ai mis des valeurs par défaut ici pour les tests pour éviter de remplir le formulaire à chaque fois
    this.connexionForm = this.formBuilder.group({
      nom: ['neograph', Validators.required],
      prenom: ['graphiste', Validators.required],
      email: ['admin2@admin.com', [Validators.required, Validators.email]],
      password: ['azertydqd', [Validators.required, Validators.minLength(6)]],
    });
  }

  submitForm() {
    this.toastr.success('Hello world!', 'Toastr fun!');
    if (this.connexionForm.valid) {
      const champEmail = this.connexionForm.get('email');
      const champPassword = this.connexionForm.get('password');
      // Vérifier si les champs sont ok
      if (champEmail && champPassword) {
        const email = champEmail.value;
        const password = champPassword.value;

        // Créer un objet avec les données récupérées
        const donneesFormulaire = {
          email: email,
          motDePasse: password,
        };

        // Envoyer les données à l'API
        //console.log(donneesFormulaire);
        const response = this.AuthService.login(donneesFormulaire)
          .then((response) => {
            // Récupération du token depuis la réponse
            const token = response.token;

            // Affichage du token
            //console.log(token);
            this.AuthService.saveToken(token);
          })
          .catch((error) => {
            console.error(error);
          });
      }
    } else {
      // Affichez des messages d'erreur ou effectuez d'autres actions appropriées si le formulaire n'est pas valide.
      console.log("Le formulaire d'inscription est invalide.");
    }
  }
}
