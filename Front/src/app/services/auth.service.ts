import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment.prod';
import { UtilisateurInscription } from '../Models/UtilisateurInscription.model';
import { UtilisateurConnexion } from '../Models/UtilisateurConnexion.model';
import { UtilisateurProfil } from '../Models/UtilisateurProfil.model';
// import * as jwt_decode from "jwt-decode";
import jwt_decode from 'jwt-decode';
import { Utilisateur } from '../Models/Utilisateur.model';

// Utilisez les fonctions et les classes de la bibliothèque jose selon vos besoins

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  private apiUrl = environment.apiURL; // Remplacez par l'URL de votre API

  constructor(private http: HttpClient) {}

  // Méthode pour enregistrer le token dans le stockage local (localStorage)
  saveToken(token: string): void {
    localStorage.setItem('token', token);
  }

  // Méthode pour récupérer le token depuis le stockage local
  getToken(): string | null {
    return localStorage.getItem('token');
  }

  // Méthode pour supprimer le token du stockage local
  removeToken(): void {
    localStorage.removeItem('token');
  }

  // Méthode pour vérifier si l'utilisateur est connecté en vérifiant la présence du token
  isAuthenticated(): boolean {
    const token = this.getToken();
    return token !== null;
  }

  register(data: UtilisateurInscription): Promise<any> {
    // Définir les en-têtes de la requête (optionnel)
    const headers = new HttpHeaders().set('Content-Type', 'text/json');
    //console.log("Envoi des données à l'API");

    //Envoyer la requête POST à l'API avec les données JSON
    return this.http
      .post(this.apiUrl + 'api/utilisateurs', data, { headers })
      .toPromise()
      .then((response) => {
        // Traiter la réponse de l'API si nécessaire
        console.log("Réponse de l'API:", response);
        return response; // Renvoyer la réponse
      })
      .catch((error) => {
        // Gérer les erreurs
        console.error("Erreur lors de l'envoi de la requête:", error);
        throw error; // Renvoyer l'erreur
      });
  }

  login(params?: UtilisateurConnexion): Promise<any> {
    // Définir les en-têtes de la requête (optionnel)
    const headers = new HttpHeaders().set('Content-Type', 'text/json');
    //console.log("Envoi de la requête GET à l'API");

    // Envoyer la requête POST à l'API avec les paramètres
    return this.http
      .post(this.apiUrl + 'api/utilisateurs/authenticate', params, { headers })
      .toPromise()
      .then((response) => {
        // Traiter la réponse de l'API si nécessaire
        console.log("Réponse de l'API:", response);
        return response; // Renvoyer la réponse
      })
      .catch((error) => {
        // Gérer les erreurs
        console.error("Erreur lors de l'envoi de la requête GET:", error);
        throw error; // Renvoyer l'erreur
      });
  }


  getDecodedAccessToken(token: string): any {
    try {
      // console.log(jwt_decode(token));
      const decodedToken = jwt_decode(token)
      return decodedToken;
    } catch(Error) {
      return null;
    }
  }

  getUtilisateurProfil(id: string): Observable<Utilisateur> {
    const headers = new HttpHeaders().set('Content-Type', 'text/json');

    return this.http.get<Utilisateur>(this.apiUrl + 'api/utilisateurs/' + id, { headers });
  }
}
