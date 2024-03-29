import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, Subject } from 'rxjs';
import { Aimer } from '../Models/Aimer.model';
import { environment } from 'src/environments/environment.prod';

@Injectable({
  providedIn: 'root',
})
export class AimerService {
  private baseUrl = environment.apiURL + 'api/Aimers';
  private newLikeAddedSource = new Subject<Aimer>(); // Source du Subject pour les nouveaux likes
  newLikeAdded$ = this.newLikeAddedSource.asObservable(); // Observable pour les nouveaux likes

  constructor(private http: HttpClient) {}

  getAllAimers(): Observable<Aimer[]> {
    return this.http.get<Aimer[]>(`${this.baseUrl}/`);
  }

  getAimerById(id: number): Observable<Aimer> {
    return this.http.get<Aimer>(`${this.baseUrl}/Utilisateur/${id}`);
  }

  createAimer(aimer: Aimer): Observable<Aimer> {
    this.newLikeAddedSource.next(aimer);
    return this.http.post<Aimer>(`${this.baseUrl}/`, aimer);
  }

  updateAimer(id: number, aimer: Aimer): Observable<Aimer> {
    return this.http.put<Aimer>(`${this.baseUrl}/${id}`, aimer);
  }

  deleteAimer(id: number): Observable<any> {
    return this.http.delete(`${this.baseUrl}/${id}`);
  }
  checkAimerExists(
    utilisateurId: number,
    ressourceId: number
  ): Observable<boolean> {
    return this.http.get<boolean>(
      `${this.baseUrl}/CheckExists?utilisateurId=${utilisateurId}&ressourceId=${ressourceId}`
    );
  }
}
