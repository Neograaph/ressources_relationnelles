import { Component, OnInit } from '@angular/core';
import { ActionsTypeService } from 'src/app/services/actions-type.service';
import { HttpClient } from '@angular/common/http';
import { catchError } from 'rxjs/operators';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css'],
})
export class NavbarComponent implements OnInit {
  public utilisateurs: any;
  public resultatPost: any;

  constructor(
    public actiontype: ActionsTypeService,
    private http: HttpClient
  ) {}

  ngOnInit(): void {
    this.actiontype.getActionType().subscribe(
      async (response: any) => {
        await this.getMethod();
        console.log(response);
      },
      (error: any) => {
        console.error(error);
      }
    );
  }

  public async getMethod() {
    try {
      const response = await this.http
        .get('https://localhost:7032/api/Utilisateurs')
        .subscribe();
      this.utilisateurs = response;
      console.log(response);
    } catch (error) {
      console.error(error);
    }
  }
}
