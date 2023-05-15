import { compileNgModule } from '@angular/compiler';
import { Component, EnvironmentInjector, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { AuthService } from 'src/app/services/auth.service';
import { RouterModule } from '@angular/router';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ToastrService } from 'ngx-toastr';
import { CommonModule } from '@angular/common';
import { NotificationsService } from 'src/app/services/notifications.service';
import { UtilisateurConnexion } from 'src/app/Models/UtilisateurConnexion.model';

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
    private NotificationsService: NotificationsService
  ) {
    this.createForm();
  }
  OnInit(): void {}

  createForm() {
    // j'ai mis des valeurs par défaut ici pour les tests pour éviter de remplir le formulaire à chaque fois
    this.connexionForm = this.formBuilder.group({
      nom: ['neograph', Validators.required],
      prenom: ['graphiste', Validators.required],
      email: ['admin@admin.com', [Validators.required, Validators.email]],
      password: ['azertyui', [Validators.required, Validators.minLength(6)]],
    });
  }

  submitForm() {
    if (this.connexionForm.valid) {
      const champEmail = this.connexionForm.get('email');
      const champPassword = this.connexionForm.get('password');
      // Vérifier si les champs sont ok
      if (champEmail && champPassword) {
        const email = champEmail.value;
        const motDePasse = champPassword.value;

        // Créer un objet Utilisateur
        const utilisateur = new UtilisateurConnexion(email, motDePasse);

        // Envoyer les données à l'API
        const response = this.AuthService.login(utilisateur)
          .then((response) => {
            const token = response.token;
            //console.log(token);
            this.AuthService.saveToken(token);
            this.NotificationsService.showSuccess(
              "Connexion à l'application validée",
              'token enregistré'
            );
          })
          .catch((error) => {
            //console.error(error);
            this.NotificationsService.showError(
              "Impossible d'accéder à l'API",
              error.message
            );
          });
      }
    } else {
      //console.log("Le formulaire d'inscription est invalide.");
      this.NotificationsService.showError(
        'Erreur de connexion',
        'Le formulaire de connexion est invalide.'
      );
    }
  }
}
