import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Ressource } from '../Models/Ressource.model';
import { environment } from 'src/environments/environment.prod';

@Injectable({
  providedIn: 'root',
})
export class RessourcesService {
  private baseUrl = environment.apiURL + 'api/Ressources';

  constructor(private http: HttpClient) {}

  getRessources(): Observable<Ressource[]> {
    return this.http.get<Ressource[]>(this.baseUrl);
  }

  getRessource(id: number): Observable<Ressource> {
    return this.http.get<Ressource>(`${this.baseUrl}/${id}`);
  }

  createRessource(ressource: Ressource): Observable<Ressource> {
    const headers = new HttpHeaders().set('Content-Type', 'text/json');

    return this.http.post<Ressource>(this.baseUrl, ressource, { headers });
  }

  updateRessource(id: number, ressource: Ressource): Observable<any> {
    return this.http.put<any>(`${this.baseUrl}/${id}`, ressource);
  }

  deleteRessource(id: number): Observable<any> {
    return this.http.delete<any>(`${this.baseUrl}/${id}`);
  }
}

// login(params?: UtilisateurConnexion): Promise<any> {
//     // Définir les en-têtes de la requête (optionnel)
//     const headers = new HttpHeaders().set('Content-Type', 'text/json');
//     //console.log("Envoi de la requête GET à l'API");

//     // Envoyer la requête POST à l'API avec les paramètres
//     return this.http
//       .post(this.apiUrl + 'api/utilisateurs/authenticate', params, { headers })
//       .toPromise()
//       .then((response) => {
//         // Traiter la réponse de l'API si nécessaire
//         console.log("Réponse de l'API:", response);
//         return response; // Renvoyer la réponse
//       })
//       .catch((error) => {
//         // Gérer les erreurs
//         console.error("Erreur lors de l'envoi de la requête GET:", error);
//         throw error; // Renvoyer l'erreur
//       });
//   }
