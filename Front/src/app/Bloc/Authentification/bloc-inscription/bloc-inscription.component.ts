import { compileNgModule } from '@angular/compiler';
import { Component } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { AuthService } from 'src/app/services/auth.service';
import { RouterModule } from '@angular/router';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NotificationsService } from 'src/app/services/notifications.service';
import { UtilisateurInscription } from 'src/app/Models/UtilisateurInscription.model';

@Component({
  selector: 'app-bloc-inscription',
  templateUrl: './bloc-inscription.component.html',
  styleUrls: ['./bloc-inscription.component.css'],
})
export class BlocInscriptionComponent {
  inscriptionForm!: FormGroup;

  constructor(
    private formBuilder: FormBuilder,
    private AuthService: AuthService,
    private NotificationsService: NotificationsService,
  ) {
    this.createForm();
  }

  createForm() {
    // j'ai mis des valeurs par défaut ici pour les tests pour éviter de remplir le formulaire à chaque fois
    this.inscriptionForm = this.formBuilder.group({
      nom: ['neo', Validators.required],
      prenom: ['graph', Validators.required],
      telephone: ['', Validators.nullValidator],
      email: ['admin@admin.com', [Validators.required, Validators.email]],
      password: ['azertyui', [Validators.required, Validators.minLength(6)]],
    });
  }

  submitForm() {
    if (this.inscriptionForm.valid) {
      const champNom = this.inscriptionForm.get('nom');
      const champPrenom = this.inscriptionForm.get('prenom');
      const champTelephone = this.inscriptionForm.get('telephone');
      const champEmail = this.inscriptionForm.get('email');
      const champPassword = this.inscriptionForm.get('password');
      // Vérifier si les champs sont ok
      if (
        champNom &&
        champPrenom &&
        champTelephone &&
        champEmail &&
        champPassword
      ) {
        const nom = champNom.value;
        const prenom = champPrenom.value;
        const telephone = champTelephone.value;
        const email = champEmail.value;
        const motDePasse = champPassword.value;

        // Créer un objet Utilisateur
        const utilisateur = new UtilisateurInscription(prenom, nom, email, motDePasse, telephone);

        // Créer un objet avec les données récupérées
        // const donneesFormulaire = {
        //   prenom: prenom,
        //   nom: nom,
        //   email: email,
        //   motDePasse: password,
        //   telephone: telephone,
        // };
        // Stocker les données dans un tableau pour les envoyer à l'API en C#
        //const tableauDonnees: any[] = [];

        //tableauDonnees.push(donneesFormulaire);
        //console.log("Le formulaire d'inscription est valide + tableau créé");
        //console.log(tableauDonnees);

        // Envoyer les données à l'API
        this.AuthService.register(utilisateur)
          .then((response) => {
            // Récupération du token depuis la réponse
            const token = response.token;

            // Affichage du token
            // console.log(utilisateur);
            // console.log(response);
            this.AuthService.saveToken(token);
            this.NotificationsService.showSuccess(
              'Inscription validée',
              'token enregistré'
            );
          })
          .catch((error) => {
            // console.log(utilisateur);
            // console.error(error);
            this.NotificationsService.showError(
              "Impossible d'accéder à l'API",
              error.error
            );
          });
      }
    } else {
      // Affichez des messages d'erreur ou effectuez d'autres actions appropriées si le formulaire n'est pas valide.
      //console.log("Le formulaire d'inscription est invalide.");
      this.NotificationsService.showError(
        'Veuillez vérifier les champs',
        "Le formulaire d'inscription est invalide."
      );
    }
  }
}
