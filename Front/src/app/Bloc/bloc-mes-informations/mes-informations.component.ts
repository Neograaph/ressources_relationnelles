import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { AuthService } from 'src/app/services/auth.service';
import { NotificationsService } from 'src/app/services/notifications.service';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Utilisateur } from '../../Models/Utilisateur.model';
import { UtilisateurService } from '../../services/utilisateur.service';
import { Observable, Subject } from 'rxjs';


@Component({
  selector: 'app-mes-informations',
  templateUrl: './mes-informations.component.html',
  styleUrls: ['./mes-informations.component.css'],
  providers: [ToastrService],
})
export class MesInformationsComponent implements OnInit {
  profilForm!: FormGroup;

  constructor(
    private formBuilder: FormBuilder,
    private AuthService: AuthService,
    private NotificationsService: NotificationsService,
    private UtilisateurService: UtilisateurService,
    private router: Router
  ) {
    this.createForm();
  }

  utilisateur?: Utilisateur;
  ngOnInit(): void {
    this.UtilisateurService.getUtilisateur().subscribe(
      (utilisateur: Utilisateur | null) => {
        if (utilisateur !== null) {
          this.utilisateur = utilisateur;
          this.patchFormValues(utilisateur);
        }
      },
      (error) => {
        this.router.navigate(['/connexion']);
        console.error(
          "Une erreur s'est produite lors de la récupération de l'utilisateur :",
          error
        );
      }
    );
  }

  createForm() {
    // j'ai mis des valeurs par défaut ici pour les tests pour éviter de remplir le formulaire à chaque fois
    this.profilForm = this.formBuilder.group({
      nom: ['test', Validators.required],
      prenom: ['test', Validators.required],
      email: ['test@admin.com', [Validators.required, Validators.email]],
      telephone: ['06 06 06 06 06', [Validators.required]],
      adresse: ['1 rue de la paix', [Validators.required]],
      ville: ['75000', [Validators.required]],
      password: ['*******', [Validators.required, Validators.minLength(6)]],
      confirmPassword: [
        '*******',
        [Validators.required, Validators.minLength(6)],
      ],
    });
  }
  patchFormValues(utilisateur: any) {
    console.log(utilisateur);

    this.profilForm.patchValue({
      nom: utilisateur.nom,
      prenom: utilisateur.prenom,
      email: utilisateur.email,
      telephone: utilisateur.telephone,
      adresse: utilisateur.adresse,
      ville: utilisateur.ville,
      password: '*********',
      confirmPassword: '*********',
    });
  }
  deleteAccount(): void {
    // Envoyer une notification à tous les observateurs que le compte doit être supprimé
    this.NotificationsService.showError("Suppression du compte", "Votre compte va être supprimé.")
  }
}
