import { Component } from "@angular/core";

@Component({
  selector: "app-mes-ressources",
  templateUrl: "./mes-ressources.component.html",
  styleUrls: ["./mes-ressources.component.css"],
})
export class MesRessourcesComponent {
  data = [
    {
      title: "Produit 1",
      image: "https://picsum.photos/seed/produit1/300/200",
      description: "Ceci est la description du produit 1"
    },
    {
      title: "Produit 2",
      image: "https://picsum.photos/seed/produit2/300/200",
      description: "Ceci est la description du produit 2"
    },
    {
      title: "Produit 3",
      image: "https://picsum.photos/seed/produit3/300/200",
      description: "Ceci est la description du produit 3"
    },
    {
      title: "Produit 4",
      image: "https://picsum.photos/seed/produit4/300/200",
      description: "Ceci est la description du produit 4"
    },
    {
      title: "Produit 5",
      image: "https://picsum.photos/seed/produit5/300/200",
      description: "Ceci est la description du produit 5"
    }
  ];
}
