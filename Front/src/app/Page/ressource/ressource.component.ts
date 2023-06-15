import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Ressource } from 'src/app/Models/Ressource.model';
import { RessourcesService } from 'src/app/services/ressource.service';

@Component({
  selector: 'app-ressource',
  templateUrl: './ressource.component.html',
  styleUrls: ['./ressource.component.css']
})
export class RessourceComponent  {
  ressource!: Ressource;
  constructor(
    private route: ActivatedRoute,
    private ressourceService: RessourcesService
  ) { }
  ngOnInit(): void {
    this.getRessource();
  }

  getRessource(): void {
    const ressourceId = this.route.snapshot.paramMap.get('id');
    this.ressourceService.getRessource(ressourceId).subscribe(
      (ressource: Ressource) => {
        this.ressource = ressource;
      },
      (error) => {
        console.error('Une erreur s\'est produite lors de la récupération de la ressource :', error);
      }
    );
  }
}


