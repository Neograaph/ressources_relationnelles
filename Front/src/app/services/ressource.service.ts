import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Ressource } from '../Models/Ressource.model';

@Injectable({
  providedIn: 'root',
})
export class RessourcesService {
  private baseUrl = 'api/Ressources';

  constructor(private http: HttpClient) {}

  getRessources(): Observable<Ressource[]> {
    return this.http.get<Ressource[]>(this.baseUrl);
  }

  getRessource(id: number): Observable<Ressource> {
    return this.http.get<Ressource>(`${this.baseUrl}/${id}`);
  }

  createRessource(ressource: Ressource): Observable<Ressource> {
    return this.http.post<Ressource>(this.baseUrl, ressource);
  }

  updateRessource(id: number, ressource: Ressource): Observable<any> {
    return this.http.put<any>(`${this.baseUrl}/${id}`, ressource);
  }

  deleteRessource(id: number): Observable<any> {
    return this.http.delete<any>(`${this.baseUrl}/${id}`);
  }
}
