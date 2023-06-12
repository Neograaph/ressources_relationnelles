import { Ressource } from "./Ressource.model";

export interface Categorie {
  categorieId: number;
  libelle: string;
  ressources: Ressource[];
}
