import { Injectable } from '@angular/core';
import { ToastrService, GlobalConfig } from 'ngx-toastr';

@Injectable({
  providedIn: 'root',
})
export class NotificationsService {
  constructor(private toastr: ToastrService) {}

  showError(title: string, message: string) {
    const config: Partial<GlobalConfig> = {
      closeButton: true, // Affiche un bouton de fermeture
      tapToDismiss: true, // Permet de fermer en cliquant dessus
      progressBar: true, // Affiche une barre de progression
      newestOnTop: true, // Les nouveaux messages apparaissent en haut
      countDuplicates: true, // Compte les doublons
    };

    this.toastr.error(message, title, config);
  }

  showSuccess(title: string, message: string) {
    const config: Partial<GlobalConfig> = {
      closeButton: true, // Affiche un bouton de fermeture
      tapToDismiss: true, // Permet de fermer en cliquant dessus
      progressBar: true, // Affiche une barre de progression
      newestOnTop: true, // Les nouveaux messages apparaissent en haut
      countDuplicates: true, // Compte les doublons
    };

    this.toastr.success(message, title, config);
  }
}
