import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { AuthService } from 'src/app/services/auth.service';
import { NotificationsService } from 'src/app/services/notifications.service';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';


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
    private router: Router
  ) { 
    this.createForm();
  }

  ngOnInit(): void { 
    const token = this.AuthService.getToken();
    
    if (token) {
      const decodedToken = this.AuthService.getDecodedAccessToken(token);
      console.log(decodedToken);
      console.log(decodedToken.name);
      
      // const utilisateur = this.AuthService.getUtilisateurProfil(token);
      

    } else {
      console.log('Pas de token');
      this.router.navigate(['/connexion']);
    }

  }

  createForm() {
    // j'ai mis des valeurs par défaut ici pour les tests pour éviter de remplir le formulaire à chaque fois
    this.profilForm = this.formBuilder.group({
      nom: ['neo', Validators.required],
      prenom: ['graph', Validators.required],
      email: ['admin@admin.com', [Validators.required, Validators.email]],
      telephone: ['06 06 06 06 06', [Validators.required]],
      adresse: ['1 rue de la paix', [Validators.required]],
      ville: ['75000', [Validators.required]],
      password: ['azertyui', [Validators.required, Validators.minLength(6)]],
      confirmPassword: ['azertyui', [Validators.required, Validators.minLength(6)]],
    });
  }
}

