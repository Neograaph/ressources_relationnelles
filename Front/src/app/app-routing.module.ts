import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { PageAuthentificationComponent } from './Page/page-authentification/page-authentification.component';
import { PageHomeComponent } from './Page/page-home/page-home.component';
import { PageVitrineComponent } from './Page/page-vitrine/page-vitrine.component';

const routes: Routes = [
  { path: 'inscription', component: PageAuthentificationComponent },
  { path: 'connexion', component: PageAuthentificationComponent },
  { path: 'accueil', component: PageHomeComponent },
  { path: '', component: PageVitrineComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
