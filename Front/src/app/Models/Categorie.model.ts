import { Ressource } from "./Ressource.model";

export class Categorie {
  categorieId: number;
  libelle: string;
  ressources: Ressource[];

  constructor() {
    this.categorieId = 0;
    this.libelle = '';
    this.ressources = [];
  }
}
