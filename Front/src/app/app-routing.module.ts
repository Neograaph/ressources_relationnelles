import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { PageAuthentificationComponent } from './Page/page-authentification/page-authentification.component';
import { PageHomeComponent } from './Page/page-home/page-home.component';
import { PageVitrineComponent } from './Page/page-vitrine/page-vitrine.component';
import { PagePlanSiteComponent } from './Page/page-plan-site/page-plan-site.component';
import { PageNotFoundComponent } from './Page/page-not-found/page-not-found.component';
import { PageProfilComponent } from './Page/page-profil/page-profil.component';

const routes: Routes = [
  { path: 'inscription', component: PageAuthentificationComponent },
  { path: 'connexion', component: PageAuthentificationComponent },
  { path: 'accueil', component: PageHomeComponent },
  { path: 'planSite', component: PagePlanSiteComponent },
  { path: 'profil', component: PageProfilComponent },
  { path: '', component: PageVitrineComponent },
  { path: '**', component: PageNotFoundComponent }

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
