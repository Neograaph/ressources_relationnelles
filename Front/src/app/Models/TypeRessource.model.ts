import { Ressource } from "./Ressource.model";

export interface TypeRessource {
  typeRessourceId: number;
  libelle: string;
  ressources: Ressource[];
}
