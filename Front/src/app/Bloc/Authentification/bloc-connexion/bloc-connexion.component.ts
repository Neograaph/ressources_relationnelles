import { compileNgModule } from '@angular/compiler';
import { Component } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { AuthService } from 'src/app/services/auth.service';
import { RouterModule } from '@angular/router';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

@Component({
  selector: 'app-bloc-connexion',
  templateUrl: './bloc-connexion.component.html',
  styleUrls: ['./bloc-connexion.component.css'],
})
export class BlocConnexionComponent {
  connexionForm!: FormGroup;

  constructor(
    private formBuilder: FormBuilder,
    private AuthService: AuthService
  ) {
    this.createForm();
  }

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
        this.AuthService.login(donneesFormulaire);
      }
    } else {
      // Affichez des messages d'erreur ou effectuez d'autres actions appropriées si le formulaire n'est pas valide.
      console.log("Le formulaire d'inscription est invalide.");
    }
  }
}
