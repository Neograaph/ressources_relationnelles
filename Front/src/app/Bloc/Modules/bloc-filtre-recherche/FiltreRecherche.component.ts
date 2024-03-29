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

  selectedCategoryId?: number | null;
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
    this.filterResources();
  }Reset(): void {
    // Réinitialisez les valeurs des filtres
    this.selectedCategoryId = undefined;
    this.selectedTypeRessourceId = undefined;
    this.publicationName = '';
    this.author = '';
    this.publicationDate = '';
    this.filterResources()
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


