import { Categorie } from "./Categorie.model";
import { TypeRessource } from "./TypeRessource.model";
import { Utilisateur } from "./Utilisateur.model";

export class Ressource {
  ressourceId!: number;
  titre!: string | null;
  dateCreation!: Date;
  contenu!: string | null;
  valider?: boolean;
  visibiliteLibelle?: string | null;
  categorieId!: number;
  categorie!: Categorie ;
  typeRessourceId!: number;
  typeRessource!: TypeRessource ;
  documentId?: number | null;
  document?: Document | null;
  utilisateurId!: number;
  utilisateur!: Utilisateur | null;
  // aimers: Aimer[] | null;
  // consulters: Consulter[] | null;
  // recherchers: Rechercher[] | null;
}
