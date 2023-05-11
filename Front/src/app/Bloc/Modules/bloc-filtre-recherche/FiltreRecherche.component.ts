import { Component, OnInit } from '@angular/core';
import { ActionsTypeService } from 'src/app/services/actions-type.service';

@Component({
  selector: 'app-FiltreRecherche',
  templateUrl: './FiltreRecherche.component.html',
  styleUrls: ['./FiltreRecherche.component.css'],
})
export class FiltreRechercheComponent implements OnInit {

  constructor(public actiontype: ActionsTypeService) { }
  ngOnInit(): void {
    this.actiontype.getActionType().subscribe((response: any) => {

      console.log(response)
    });
  }

}

