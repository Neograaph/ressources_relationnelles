import { Injectable } from '@angular/core';
import { Subject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class FiltreRechercheService {

  constructor() { }
  private filterChangeSubject = new Subject<any>();

  filterChange$ = this.filterChangeSubject.asObservable();

  updateFilter(filter: any): void {
    this.filterChangeSubject.next(filter);
  }
}
