import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment.prod';


@Injectable({
  providedIn: 'root'
})
export class ActionsTypeService {

  constructor(private http: HttpClient) { }
//Http Client get method
public getActionType(): Observable<any> {
  return this.http.get<any>(environment.apiURL);
}

}
