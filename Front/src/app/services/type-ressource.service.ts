import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { TypeRessource } from '../Models/TypeRessource.model';

@Injectable({
  providedIn: 'root'
})

export class TypeRessourceService {
  private apiUrl = environment.apiURL; // Remplacez par l'URL de votre API


  constructor(private http: HttpClient) { }

  getTypeRessource(typeRessourceId: number): Observable<TypeRessource> {
    const url = `${this.apiUrl}api/typeressources/${typeRessourceId}`;
    return this.http.get<TypeRessource>(url);
  }

  getAllTypeRessources(): Observable<TypeRessource[]> {
    const url = `${this.apiUrl}api/typeressources`;
    return this.http.get<TypeRessource[]>(url);
  }

  createTypeRessource(typeRessource: TypeRessource): Observable<TypeRessource> {
    const url = `${this.apiUrl}api/typeressources`;
    return this.http.post<TypeRessource>(url, typeRessource);
  }

  updateTypeRessource(typeRessourceId: number, typeRessource: TypeRessource): Observable<void> {
    const url = `${this.apiUrl}api/typeressources/${typeRessourceId}`;
    return this.http.put<void>(url, typeRessource);
  }

  deleteTypeRessource(typeRessourceId: number): Observable<void> {
    const url = `${this.apiUrl}api/typeressources/${typeRessourceId}`;
    return this.http.delete<void>(url);
  }
}
