import { compileNgModule } from '@angular/compiler';
import { Component } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';

@Component({
  selector: 'app-bloc-inscription',
  templateUrl: './bloc-inscription.component.html',
  styleUrls: ['./bloc-inscription.component.css'],
})
export class BlocInscriptionComponent {
  inscriptionForm!: FormGroup;

  constructor(private formBuilder: FormBuilder) {
    this.createForm();
  }

  createForm() {
    // j'ai mis des valeurs par défaut ici pour les tests pour éviter de remplir le formulaire à chaque fois
    this.inscriptionForm = this.formBuilder.group({
      nom: ['neo', Validators.required],
      prenom: ['graph', Validators.required],
      email: ['admin@admin.com', [Validators.required, Validators.email]],
      password: ['azerty', [Validators.required, Validators.minLength(6)]],
    });
  }

  submitForm() {
    if (this.inscriptionForm.valid) {
      const champNom = this.inscriptionForm.get('nom');
      const champPrenom = this.inscriptionForm.get('prenom');
      const champEmail = this.inscriptionForm.get('email');
      const champPassword = this.inscriptionForm.get('password');
      // Vérifier si les champs sont ok
      if (champNom && champPrenom && champEmail && champPassword) {
        const nom = champNom.value;
        const prenom = champPrenom.value;
        const email = champEmail.value;
        const password = champPassword.value;

        // Créer un objet avec les données récupérées
        const donneesFormulaire = {
          prenom: prenom,
          nom: nom,
          email: email,
          password: password,
        };
        // Stocker les données dans un tableau pour les envoyer à l'API en C#
        const tableauDonnees: any[] = [];

        tableauDonnees.push(donneesFormulaire);
        console.log("Le formulaire d'inscription est valide + tableau créé");
        console.log(tableauDonnees);
      }

      // Exemple : envoyer les données à l'API en C#
      // fetch('https://votre-api.com/endpoint', {
      //   method: 'POST',
      //   headers: {
      //     'Content-Type': 'application/json'
      //   },
      //   body: JSON.stringify(donneesFormulaire)
      // })
      // .then(response => {
      //   // Traiter la réponse de l'API
      // })
      // .catch(error => {
      //   // Gérer les erreurs
      // });

      // Traitez les données d'inscription ici, par exemple, appelez un service pour envoyer les données au serveur.
      //console.log(this.inscriptionForm.value);
    } else {
      // Affichez des messages d'erreur ou effectuez d'autres actions appropriées si le formulaire n'est pas valide.
      console.log("Le formulaire d'inscription est invalide.");
    }
  }
}
