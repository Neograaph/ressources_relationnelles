import { Component, OnInit } from '@angular/core';
import { ActionsTypeService } from 'src/app/services/actions-type.service';
import { ToastrService } from 'ngx-toastr';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Ressource } from 'src/app/Models/Ressource.model';
import { NotificationsService } from 'src/app/services/notifications.service';
import { RessourcesService } from '../../../services/ressource.service';
import { RefreshService } from 'src/app/services/refresh-service.service';

@Component({
  selector: 'app-mes-ressources',
  templateUrl: './mes-ressources.component.html',
  styleUrls: ['./mes-ressources.component.css'],
  providers: [ToastrService],
})
export class MesRessourcesComponent {
  constructor(
    private NotificationsService: NotificationsService,
    private RessourcesService: RessourcesService,
    private refreshService: RefreshService
  ) {}
  ressource!: Ressource;
  Ressources: Array<Ressource> = [];
  ngOnInit(): void {
    this.getRessources();
    this.refreshService.refresh$.subscribe(() => {
      // console.log('refresh222');
      // Effectuez les actions de rafraîchissement nécessaires dans ce composant
      // par exemple, rechargez les données ou exécutez une fonction spécifique
      this.getRessources();
    });
  }
  getRessources() {
    this.RessourcesService.getRessources().subscribe((data) => {
      this.Ressources = this.sortRessourcesByDate(data);
      console.log(data);
    });
  }
  // sortRessourcesByDate(ressources: Ressource[]): Ressource[] {
  //   return ressources.sort((a, b) => {
  //     return (
  //       new Date(b.dateCreation).getTime() - new Date(a.dateCreation).getTime()
  //     );
  //   });
  // }
  sortRessourcesByDate(ressources: Ressource[]): Ressource[] {
    return ressources.sort((a, b) => {
      return (
        new Date(a.dateCreation).getTime() - new Date(b.dateCreation).getTime()
      );
    });
  }
}
