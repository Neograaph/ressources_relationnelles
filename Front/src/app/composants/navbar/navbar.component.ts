import { Component, OnInit } from '@angular/core';
import { ActionsTypeService } from 'src/app/services/actions-type.service';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent implements OnInit {


  constructor(public actiontype: ActionsTypeService) { }

  ngOnInit(): void {
    this.actiontype.getActionType().subscribe((response: any) => {

      console.log(response)
    });
  }

}

