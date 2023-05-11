import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NavbarComponent } from './composants/navbar/navbar.component';
import { PostRessourceComponent } from './composants/PostRessource/PostRessource.component';
import { FiltreRechercheComponent } from './composants/FiltreRecherche/FiltreRecherche.component';
import { FavRessourceComponent } from './composants/FavRessource/FavRessource.component';
import { MesRessourcesComponent } from './composants/mes-ressources/mes-ressources.component';


@NgModule({
  declarations: [
    AppComponent,
    NavbarComponent,
    PostRessourceComponent,
    FiltreRechercheComponent,
    FavRessourceComponent
    MesRessourcesComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
