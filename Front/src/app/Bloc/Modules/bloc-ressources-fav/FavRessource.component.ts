import { Component, OnInit } from '@angular/core';
import { ActionsTypeService } from 'src/app/services/actions-type.service';

@Component({
  selector: 'app-FavRessource',
  templateUrl: './FavRessource.component.html',
  styleUrls: ['./FavRessource.component.css'],
})
export class FavRessourceComponent implements OnInit {

  constructor(public actiontype: ActionsTypeService) { }
  ngOnInit(): void {
    this.actiontype.getActionType().subscribe((response: any) => {

      console.log(response)
    });
  }

}

