import { Component, OnInit } from '@angular/core';
import { Categorie } from 'src/app/Models/Categorie.model';
import { TypeRessource } from 'src/app/Models/TypeRessource.model';
import { ActionsTypeService } from 'src/app/services/actions-type.service';
import { CategorieService } from 'src/app/services/categorie.service';
import { FiltreRechercheService } from 'src/app/services/filtre-recherche.service';
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
    public typeRessService: TypeRessourceService,
    private filtreService: FiltreRechercheService
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
    this.filterResources();
  }
  filterResources(): void {
    // Effectuez le filtrage en fonction des valeurs des filtres

    // ...

    // Mettez à jour le filtre en utilisant le service de partage de données
    const filter = {
      selectedCategoryId: this.selectedCategoryId,
      selectedTypeRessourceId: this.selectedTypeRessourceId,
      publicationName: this.publicationName,
      author: this.author,
      publicationDate: this.publicationDate
    };
    this.filtreService.updateFilter(filter);
  }
}


