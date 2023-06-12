import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Categorie } from '../Models/Categorie.model';

@Injectable({
  providedIn: 'root'
})

export class CategorieService {
  private apiUrl = environment.apiURL; // Remplacez par l'URL de votre API

  constructor(private http: HttpClient) { }

  getCategorie(categorieId: number): Observable<Categorie> {
    const url = `${this.apiUrl}api/categories/${categorieId}`;
    return this.http.get<Categorie>(url);
  }

  getAllCategories(): Observable<Categorie[]> {
    const url = `${this.apiUrl}api/categories`;
    return this.http.get<Categorie[]>(url);
  }

  createCategorie(categorie: Categorie): Observable<Categorie> {
    const url = `${this.apiUrl}api/categories`;
    return this.http.post<Categorie>(url, categorie);
  }

  updateCategorie(categorieId: number, categorie: Categorie): Observable<void> {
    const url = `${this.apiUrl}api/categories/${categorieId}`;
    return this.http.put<void>(url, categorie);
  }

  deleteCategorie(categorieId: number): Observable<void> {
    const url = `${this.apiUrl}/categories/${categorieId}`;
    return this.http.delete<void>(url);
  }
}
