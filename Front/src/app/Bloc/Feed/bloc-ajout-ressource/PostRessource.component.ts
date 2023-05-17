import { Component, OnInit } from '@angular/core';
import { ActionsTypeService } from 'src/app/services/actions-type.service';
import { ToastrService } from 'ngx-toastr';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';



@Component({
  selector: 'app-PostRessource',
  templateUrl: './PostRessource.component.html',
  styleUrls: ['./PostRessource.component.css'],
  providers: [ToastrService],
})
export class PostRessourceComponent implements OnInit {
  ajoutRessourceForm!: FormGroup;

  constructor(
    public actiontype: ActionsTypeService,
    private formBuilder: FormBuilder
  ) {
    this.createForm();
  }

  ngOnInit(): void {
    // this.actiontype.getActionType().subscribe((response: any) => {
    //   console.log(response)
    // });
  }
  createForm() {
    // j'ai mis des valeurs par défaut ici pour les tests pour éviter de remplir le formulaire à chaque fois
    this.ajoutRessourceForm = this.formBuilder.group({
      titre: ['test', Validators.required],
      description: ['06 06 06 06 06', [Validators.required]],
    });
  }
}

