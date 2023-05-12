import { Component, OnInit } from '@angular/core';
import { ActionsTypeService } from 'src/app/services/actions-type.service';
@Component({
  selector: 'app-page-vitrine',
  templateUrl: './page-vitrine.component.html',
  styleUrls: ['./page-vitrine.component.css']

})
export class PageVitrineComponent  implements OnInit  {
  constructor(public actiontype: ActionsTypeService) { }
  ngOnInit(): void {
    this.actiontype.getActionType().subscribe((response: any) => {

      console.log(response)
    });
  }
}

