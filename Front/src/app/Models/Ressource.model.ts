export class Ressource {
  ressourceId: number;
  titre?: string;
  dateCreation: Date;
  contenu?: string;
  valider: boolean;
  visibiliteLibelle?: string;
  categorieLibelle?: string;
  documentId?: number;
  document?: Document;
  utilisateurId: number;
  // utilisateur?: Utilisateur;
  // aimers?: Aimer[];
  // consulters?: Consulter[];
  // recherchers?: Rechercher[];

  constructor(
    ressourceId: number,
    dateCreation: Date,
    valider: boolean,
    utilisateurId: number,
    titre?: string,
    contenu?: string,
    visibiliteLibelle?: string,
    categorieLibelle?: string,
    documentId?: number,
    document?: Document
    // utilisateur?: Utilisateur,
    // aimers?: Aimer[],
    // consulters?: Consulter[],
    // recherchers?: Rechercher[]
  ) {
    this.ressourceId = ressourceId;
    this.dateCreation = dateCreation;
    this.valider = valider;
    this.utilisateurId = utilisateurId;
    this.titre = titre;
    this.contenu = contenu;
    this.visibiliteLibelle = visibiliteLibelle;
    this.categorieLibelle = categorieLibelle;
    this.documentId = documentId;
    this.document = document;
    // this.utilisateur = utilisateur;
    // this.aimers = aimers;
    // this.consulters = consulters;
    // this.recherchers = recherchers;
  }
}
