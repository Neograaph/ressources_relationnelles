import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NavbarComponent } from './Bloc/Utilitaire/bloc-navbar/bloc-navbar.component';
import { PostRessourceComponent } from './Bloc/Feed/bloc-ajout-ressource/PostRessource.component';
import { FiltreRechercheComponent } from './Bloc/Modules/bloc-filtre-recherche/FiltreRecherche.component';
import { FavRessourceComponent } from './Bloc/Modules/bloc-ressources-fav/FavRessource.component';
import { MesRessourcesComponent } from './Bloc/Modules/bloc-mes-ressources/mes-ressources.component';
import { PageVitrineComponent } from './Page/page-vitrine/page-vitrine.component';
import { PageAuthentificationComponent } from './Page/page-authentification/page-authentification.component';
import { PageHomeComponent } from './Page/page-home/page-home.component';
import { PageProfilComponent } from './Page/page-profil/page-profil.component';
import { BlocFooterComponent } from './Bloc/Utilitaire/bloc-footer/bloc-footer.component';
import { BlocInscriptionComponent } from './Bloc/Authentification/bloc-inscription/bloc-inscription.component';
import { BlocConnexionComponent } from './Bloc/Authentification/bloc-connexion/bloc-connexion.component';
import { BlocMesRelationsComponent } from './Bloc/Modules/bloc-mes-relations/bloc-mes-relations.component';
import { BlocRessourceComponent } from './Bloc/Feed/bloc-ressource/bloc-ressource.component';
import { BlocRessourcesComponent } from './Bloc/Feed/bloc-ressources/bloc-ressources.component';
import { MesInformationsComponent } from './Bloc/bloc-mes-informations/mes-informations.component';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';

import { CommonModule } from '@angular/common';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ToastrModule } from 'ngx-toastr';
import { PageNotFoundComponent } from './Page/page-not-found/page-not-found.component';

@NgModule({
  declarations: [
    AppComponent,
    NavbarComponent,
    PostRessourceComponent,
    FiltreRechercheComponent,
    FavRessourceComponent,
    MesRessourcesComponent,
    PageVitrineComponent,
    PageAuthentificationComponent,
    PageHomeComponent,
    PageProfilComponent,
    BlocFooterComponent,
    BlocConnexionComponent,
    BlocInscriptionComponent,
    BlocMesRelationsComponent,
    BlocRessourceComponent,
    BlocRessourcesComponent,
    MesInformationsComponent,
    PageNotFoundComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    ReactiveFormsModule,
    CommonModule,
    BrowserAnimationsModule,
    ToastrModule.forRoot({ timeOut: 2000, enableHtml: true }),
  ],
  providers: [ToastrModule],
  bootstrap: [AppComponent],
})
export class AppModule {}
