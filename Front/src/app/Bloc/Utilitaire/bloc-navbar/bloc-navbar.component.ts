import { Component, OnInit } from '@angular/core';
import { ActionsTypeService } from 'src/app/services/actions-type.service';
import { HttpClient } from '@angular/common/http';
import { catchError } from 'rxjs/operators';

@Component({
  selector: 'app-bloc-navbar',
  templateUrl: './bloc-navbar.component.html',
  styleUrls: ['./bloc-navbar.component.css'],
})
export class NavbarComponent implements OnInit {
  public utilisateurs: any;
  public resultatPost: any;

  constructor(
    public actiontype: ActionsTypeService,
    private http: HttpClient
  ) {}

  ngOnInit(): void {}
}
