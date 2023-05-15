import { Component, OnInit } from '@angular/core';
import { ActionsTypeService } from 'src/app/services/actions-type.service';

@Component({
  selector: 'app-PostRessource',
  templateUrl: './PostRessource.component.html',
  styleUrls: ['./PostRessource.component.css'],
})
export class PostRessourceComponent implements OnInit {

  constructor(public actiontype: ActionsTypeService) { }
  ngOnInit(): void {
    // this.actiontype.getActionType().subscribe((response: any) => {

    //   console.log(response)
    // });
  }

}

