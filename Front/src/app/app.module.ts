import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NavbarComponent } from './composants/navbar/navbar.component';
import { MesRessourcesComponent } from './composants/mes-ressources/mes-ressources.component';

@NgModule({
  declarations: [
    AppComponent,
    NavbarComponent,
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
