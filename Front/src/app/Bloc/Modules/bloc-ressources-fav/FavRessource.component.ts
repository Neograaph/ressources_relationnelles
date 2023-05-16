import { Component, OnInit } from '@angular/core';
import { ActionsTypeService } from 'src/app/services/actions-type.service';

@Component({
  selector: 'app-FavRessource',
  templateUrl: './FavRessource.component.html',
  styleUrls: ['./FavRessource.component.css'],
})
export class FavRessourceComponent {

<<<<<<< HEAD
  constructor(public actiontype: ActionsTypeService) { }
  ngOnInit(): void {
    // this.actiontype.getActionType().subscribe((response: any) => {

    //   console.log(response)
    // });
  }
}
=======
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

>>>>>>> 6c46378b2da5bb8f62d729b4104cd1d4a9756422
