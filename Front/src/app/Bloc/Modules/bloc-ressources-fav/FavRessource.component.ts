import { Component, OnInit } from '@angular/core';
import { ActionsTypeService } from 'src/app/services/actions-type.service';

@Component({
  selector: 'app-FavRessource',
  templateUrl: './FavRessource.component.html',
  styleUrls: ['./FavRessource.component.css'],
})
export class FavRessourceComponent {

  data = [
    {
      title: "Ressources 1",
      date: "15/05/2023",
    },
    {
      title: "Produit 2",
      date: "15/05/2023",
    },
    {
      title: "Produit 3",
      date: "15/05/2023",
    },
    {
      title: "Produit 4",
      date: "15/05/2023",
    },
    {
      title: "Produit 5",
      date: "15/05/2023",
    }
  ];

}

