import { Injectable } from '@angular/core';
import { AuthService } from './auth.service';
import { Utilisateur } from '../Models/Utilisateur.model';
import { Observable, of } from 'rxjs';
import { Aimer } from '../Models/Aimer.model';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment.prod';

@Injectable({
  providedIn: 'root'
})
export class UtilisateurService {
  private apiUrl = environment.apiURL; // Remplacez par l'URL de votre API

  constructor(private authService: AuthService,private http: HttpClient) { }
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
 getAimersByUserId(userId: number): Observable<Aimer[]> {
    const url = this.apiUrl +`api/utilisateurs/${userId}/aimers`;
    return this.http.get<Aimer[]>(url);
  }
}
