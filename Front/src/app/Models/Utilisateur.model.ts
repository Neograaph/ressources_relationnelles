export class Utilisateur {
  utilisateurId: number;
  nom?: string;
  prenom?: string;
  motDePasse?: string;
  telephone?: string;
  email?: string;
  utilisateurActif: boolean;
  dateCreation: Date;
  derniereConnexion?: Date;
  dateNaissance: Date;
  role? : String;

  constructor(utilisateurId: number, utilisateurActif: boolean, dateCreation: Date, dateNaissance: Date) {
    this.utilisateurId = utilisateurId;
    this.utilisateurActif = utilisateurActif;
    this.dateCreation = dateCreation;
    this.dateNaissance = dateNaissance;
  }
}
