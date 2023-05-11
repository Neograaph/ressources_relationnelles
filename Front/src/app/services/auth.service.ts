import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment.prod';

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  private apiUrl = environment.apiURL; // Remplacez par l'URL de votre API

  constructor(private http: HttpClient) {}

  login(credentials: any): Observable<any> {
    // Envoyer les identifiants de connexion à votre API pour obtenir le token
    return this.http.post(`${this.apiUrl}/api/login`, credentials);
  }

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

  envoyerDonnees(data: any) {
    // Définir les en-têtes de la requête (optionnel)
    const headers = new HttpHeaders().set('Content-Type', 'application/json');
    console.log("Envoi des données à l'API");

    //Envoyer la requête POST à l'API avec les données JSON
    return this.http
      .post(this.apiUrl, data, { headers })
      .toPromise()
      .then((response) => {
        // Traiter la réponse de l'API si nécessaire
        console.log("Réponse de l'API:", response);
      })
      .catch((error) => {
        // Gérer les erreurs
        console.error("Erreur lors de l'envoi de la requête:", error);
      });
  }
}
