import { Utilisateur } from "./Utilisateur.model";

export class Relation {
  public RelationId!: number;
  public UtilisateurId!: number;
  public Utilisateur?: Utilisateur;
  public UtilisateurRelationId!: number;
  public UtilisateurRelation?: Utilisateur;
  public Type!: number;
  public Libelle?: string;
}
