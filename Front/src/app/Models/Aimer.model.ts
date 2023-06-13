import { Ressource } from './Ressource.model';
import { Utilisateur } from './Utilisateur.model';

export interface Aimer {
  aimerId?: number;
  ressourceId: number;
  ressource?: Ressource;
  dateAimer: Date;
  utilisateurId: number;
  utilisateur?: Utilisateur;
  titre ?: string; // Ajout du champ "titre" pour stocker le titre de la ressource
}
