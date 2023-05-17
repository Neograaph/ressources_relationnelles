import { Component, OnInit } from '@angular/core';
import { ActionsTypeService } from 'src/app/services/actions-type.service';
import { ToastrService } from 'ngx-toastr';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Ressource } from 'src/app/Models/Ressource.model';
import { NotificationsService } from 'src/app/services/notifications.service';
import { RessourcesService } from '../../../services/ressource.service';

@Component({
  selector: 'app-mes-ressources',
  templateUrl: './mes-ressources.component.html',
  styleUrls: ['./mes-ressources.component.css'],
  providers: [ToastrService],
})
export class MesRessourcesComponent {
  constructor(
    private NotificationsService: NotificationsService,
    private RessourcesService: RessourcesService
  ) {}
  ressource!: Ressource;
  Ressources: Array<Ressource> = [];
  ngOnInit(): void {
    this.getRessources();
  }
  getRessources() {
    this.RessourcesService.getRessources().subscribe((data) => {
      this.Ressources = data;
      console.log(data);
    });
  }
}
