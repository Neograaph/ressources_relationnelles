import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Aimer } from '../Models/Aimer.model';

@Injectable({
  providedIn: 'root',
})
export class AimerService {
  private baseUrl = 'chemin/vers/l/api';

  constructor(private http: HttpClient) {}

  getAllAimers(): Observable<Aimer[]> {
    return this.http.get<Aimer[]>(`${this.baseUrl}/aimers`);
  }

  getAimerById(id: number): Observable<Aimer> {
    return this.http.get<Aimer>(`${this.baseUrl}/aimers/${id}`);
  }

  createAimer(aimer: Aimer): Observable<Aimer> {
    return this.http.post<Aimer>(`${this.baseUrl}/aimers`, aimer);
  }

  updateAimer(id: number, aimer: Aimer): Observable<Aimer> {
    return this.http.put<Aimer>(`${this.baseUrl}/aimers/${id}`, aimer);
  }

  deleteAimer(id: number): Observable<any> {
    return this.http.delete(`${this.baseUrl}/aimers/${id}`);
  }
}
