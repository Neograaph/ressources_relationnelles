'@angular/core';
import { Router } from '@angular/router';
import { Utilisateur } from 'src/app/Models/Utilisateur.model';
import { AuthService } from 'src/app/services/auth.service';
import { UtilisateurService } from 'src/app/services/utilisateur.service';
import { RessourcesService } from 'src/app/services/ressource.service';
import { Ressource } from 'src/app/Models/Ressource.model';
import { Component, OnInit, ViewChild } from '@angular/core';
import {
  ChartComponent,
  ApexAxisChartSeries,
  ApexChart,
  ApexXAxis,
  ApexTitleSubtitle
} from "ng-apexcharts";

export type ChartOptions = {
  series: ApexAxisChartSeries;
  chart: ApexChart;
  xaxis: ApexXAxis;
  title: ApexTitleSubtitle;
};


@Component({
  selector: 'app-admin',
  templateUrl: './admin.component.html',
  styleUrls: ['./admin.component.css']
})
export class AdminComponent implements OnInit {
  utilisateur!: Utilisateur;

  ressourcesParType: Ressource[] = [];
  @ViewChild("chart") chart?: ChartComponent;

  public chartOptions!: Partial<ChartOptions> & { xaxis: ApexXAxis } &  { series: ApexXAxis }& { title: ApexTitleSubtitle }& { chart: ApexChart } ;


  constructor(
    private router : Router,
    private utilisateurService : UtilisateurService,
    private auth : AuthService,
    private ressourceService : RessourcesService
  ) {
    this.chartOptions = {
      series: [
        {
          name: "My-series",
          data: [10, 41, 35, 51, 49, 62, 69, 91, 148]
        }
      ],
      chart: {
        height: 350,
        type: "bar"
      },
      title: {
        text: "Nombre d'utilisateurs par mois"
      },
      xaxis: {
        categories: ["Jan", "Feb",  "Mar",  "Apr",  "May",  "Jun",  "Jul",  "Aug", "Sep"]
      }
    };
  }
  ngOnInit(): void {
    this.utilisateurService.getUtilisateur().subscribe(
      (utilisateur: Utilisateur | null) => {
        if (utilisateur !== null) {
          this.utilisateur = utilisateur;
          if (this.utilisateur.role != "Administrateur") {
            this.router.navigate(['/accueil']);
          }
        } else {
          this.router.navigate(['/accueil']);
        }
      },
      (error) => {
        this.router.navigate(['/accueil']);
        console.error("Une erreur s'est produite lors de la récupération de l'utilisateur :", error);
      }
    );
    this.ressourceService.getRessources().subscribe(data=> {
      this.ressourcesParType = data;

    });

  }
}
