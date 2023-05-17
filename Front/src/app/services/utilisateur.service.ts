import { Injectable } from '@angular/core';
import { AuthService } from './auth.service';
import { Utilisateur } from '../Models/Utilisateur.model';
import { Observable, of } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class UtilisateurService {

  constructor(private authService: AuthService) { }
  getUtilisateur(): Observable<Utilisateur | null> {
    const token = this.authService.getToken();
    if (token) {
      const decodedToken = this.authService.getDecodedAccessToken(token);
      return this.authService.getUtilisateurProfil(decodedToken.UtilisateurId);
    } else {
      console.log('Pas de token');
      // Vous pouvez choisir de gérer cette redirection depuis le service ou depuis le composant appelant.
      // this.router.navigate(['/connexion']);
      return of(null); // Utilisez la fonction 'of' de RxJS pour renvoyer un Observable contenant null
    }
  }

}
