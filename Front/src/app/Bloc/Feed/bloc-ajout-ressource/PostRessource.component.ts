import { Component, OnInit } from '@angular/core';
import { ActionsTypeService } from 'src/app/services/actions-type.service';
import { ToastrService } from 'ngx-toastr';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Ressource } from 'src/app/Models/Ressource.model';
import { Categorie } from 'src/app/Models/Categorie.model';
import { NotificationsService } from 'src/app/services/notifications.service';
import { RessourcesService } from '../../../services/ressource.service';
import { RefreshService } from 'src/app/services/refresh-service.service';
import { UtilisateurService } from 'src/app/services/utilisateur.service';
import { Utilisateur } from 'src/app/Models/Utilisateur.model';
import { TypeRessource } from 'src/app/Models/TypeRessource.model';
import { CategorieService } from 'src/app/services/categorie.service';
import { TypeRessourceService } from 'src/app/services/type-ressource.service';

@Component({
  selector: 'app-PostRessource',
  templateUrl: './PostRessource.component.html',
  styleUrls: ['./PostRessource.component.css'],
  providers: [ToastrService],
})
export class PostRessourceComponent implements OnInit {
  ajoutRessourceForm!: FormGroup;
  utilisateur!: Utilisateur;
  typeRess: TypeRessource[] = [];
  categories: Categorie[] = [];
  typeRessources : TypeRessource[]= [];
  selectedCategoryId?: number;
  selectedFile!: File;
  constructor(
    public actiontype: ActionsTypeService,
    private formBuilder: FormBuilder,
    private NotificationsService: NotificationsService,
    private RessourcesService: RessourcesService,
    private refreshService: RefreshService,
    private utilisateurService: UtilisateurService,
    public categorieService: CategorieService,
    public typeRessService: TypeRessourceService,

  ) {
    this.ajoutRessourceForm = this.formBuilder.group({
      categorie: ['', Validators.required],
      typeRessource: ['', Validators.required],
      titre: ['', Validators.required],
      contenu: ['', Validators.required]
    });
  }
  ressource!: Ressource;
  ngOnInit(): void {
    this.categorieService.getAllCategories().subscribe((categoriesData) => {
      this.categories = categoriesData;
    });
    this.typeRessService.getAllTypeRessources().subscribe((typeRessources) => {
      this.typeRessources = typeRessources;
    });
    this.utilisateurService.getUtilisateur().subscribe(
      (utilisateur: Utilisateur | null) => {
        if (utilisateur !== null) {
          this.utilisateur = utilisateur;
        }
      },
      (error) => {
        console.error("Une erreur s'est produite lors de la récupération de l'utilisateur :", error);
      }
    );
  }
  // publierRessource() {
  //   if (this.ajoutRessourceForm.valid) {
  //     this.ressource = this.ajoutRessourceForm.value;
  //     this.ressource.dateCreation = new Date();
  //     this.ressource.valider = true;
  //     this.ressource.utilisateurId = this.utilisateur.utilisateurId;
  //     this.ressource.visibiliteLibelle = 'Public';
  //     this.ressource.typeRessourceId = 5;
  //     // Vérifier si la propriété 'categorie' est null avant de lui attribuer une valeur
  //     if (this.ressource.categorie === null) {
  //       this.ressource.categorie = new Categorie(); // Initialiser la propriété 'categorie' avec un nouvel objet Categorie
  //     }
  //     this.ressource.categorieId = this.selectedCategoryId ?? 1;

  //     this.NotificationsService.showSuccess('Succès', 'Ressource ajoutée');
  //     console.log(this.ressource);
  //     this.RessourcesService.createRessource(this.ressource).subscribe();
  //     this.ajoutRessourceForm.reset();
  //     this.triggerRefresh();
  //   } else {
  //     this.NotificationsService.showError('Erreur', 'Veuillez remplir tous les champs');
  //   }
  // }
  publierRessource(): void {
    if (this.ajoutRessourceForm.invalid) {
    console.log("test")

      return;
    }

    // Créer un objet FormData pour envoyer le fichier
    const formData = new FormData();
    formData.append('categorieId', this.ajoutRessourceForm.get('categorie')?.value);
    formData.append('typeRessourceId', this.ajoutRessourceForm.get('typeRessource')?.value);
    formData.append('titre', this.ajoutRessourceForm.get('titre')?.value);
    formData.append('contenu', this.ajoutRessourceForm.get('contenu')?.value);
    formData.append('fichier', this.selectedFile);
    formData.append('utilisateurId', this.utilisateur.utilisateurId.toString());

    // Appeler le service pour envoyer le formulaire
    this.RessourcesService.publierRessource(formData)
      .subscribe(response => {
        // Traiter la réponse du serveur
        this.NotificationsService.showSuccess('Succès', 'Ressource ajoutée');
        this.ngOnInit();
      });
  }
  triggerRefresh(): void {
    this.refreshService.triggerRefresh();
  }

  onFileSelect(event: any): void {
      this.selectedFile = event.target.files[0];
  }
}
