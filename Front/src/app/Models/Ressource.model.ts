import { Aimer } from "./Aimer.model";
import { Categorie } from "./Categorie.model";
import { TypeRessource } from "./TypeRessource.model";
import { Utilisateur } from "./Utilisateur.model";
import { Document } from "./Document.model";

export class Ressource {
  public ressourceId!: number;
  public titre?: string;
  public dateCreation!: Date;
  public contenu?: string;
  public valider!: boolean;
  public visibiliteLibelle?: string;
  public categorieId!: number;
  public categorie?: Categorie;
  public typeRessourceId!: number;
  public typeRessource?: TypeRessource;
  public documentId?: number | null;
  public document?: Document | null;
  public utilisateurId!: number;
  public utilisateur?: Utilisateur;
  public aimers?: Aimer[] | null;
  // public consulters?: Consulter[] | null;
  // public recherchers?: Rechercher[] | null;
}

