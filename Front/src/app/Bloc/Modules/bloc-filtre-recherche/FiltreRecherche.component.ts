import { Component, OnInit } from '@angular/core';
import { Categorie } from 'src/app/Models/Categorie.model';
import { TypeRessource } from 'src/app/Models/TypeRessource.model';
import { ActionsTypeService } from 'src/app/services/actions-type.service';
import { CategorieService } from 'src/app/services/categorie.service';
import { TypeRessourceService } from 'src/app/services/type-ressource.service';

@Component({
  selector: 'app-FiltreRecherche',
  templateUrl: './FiltreRecherche.component.html',
  styleUrls: ['./FiltreRecherche.component.css'],
})
export class FiltreRechercheComponent implements OnInit {
  categories: Categorie[] = [];
  typeRess: TypeRessource[] = [];

  selectedCategoryId?: number;
  selectedTypeRessourceId?: number;
  publicationName?: string;
  author?: string;
  publicationDate?: string;

  constructor(
    public actiontype: ActionsTypeService,
    public categorieService: CategorieService,
    public typeRessService: TypeRessourceService
  ) {}

  ngOnInit(): void {
    this.categorieService.getAllCategories().subscribe((categoriesData) => {
      this.categories = categoriesData;
    });
    this.typeRessService.getAllTypeRessources().subscribe((typeRessData) => {
      this.typeRess = typeRessData;
    });
  }

  onSearch(): void {
    // Utilisez les valeurs des propriétés pour effectuer votre recherche
    console.log('Catégorie sélectionnée :', this.selectedCategoryId);
    console.log('Type de ressource sélectionné :', this.selectedTypeRessourceId);
    console.log('Nom de la publication :', this.publicationName);
    console.log('Auteur :', this.author);
    console.log('Date de publication :', this.publicationDate);
  }
}


