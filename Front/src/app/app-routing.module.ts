import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { PageAuthentificationComponent } from './Page/page-authentification/page-authentification.component';
import { PageHomeComponent } from './Page/page-home/page-home.component';
import { PageVitrineComponent } from './Page/page-vitrine/page-vitrine.component';
import { PagePlanSiteComponent } from './Page/page-plan-site/page-plan-site.component';
import { PageNotFoundComponent } from './Page/page-not-found/page-not-found.component';
import { PageProfilComponent } from './Page/page-profil/page-profil.component';
import { PageMentionsLegalesComponent } from './Page/page-mentions-legales/page-mentions-legales.component';
import { PageDonneesPersonnellesComponent } from './Page/page-donnees-personnelles/page-donnees-personnelles.component';
import { PageCookiesComponent } from './Page/page-cookies/page-cookies.component';
import { RessourceComponent } from './Page/ressource/ressource.component';
import { AdminComponent } from './Page/admin/admin.component';

const routes: Routes = [
  { path: '', component: PageVitrineComponent },
  { path: 'inscription', component: PageAuthentificationComponent },
  { path: 'connexion', component: PageAuthentificationComponent },
  { path: 'accueil', component: PageHomeComponent },
  { path: 'planSite', component: PagePlanSiteComponent },
  { path: 'mentionsLegales', component: PageMentionsLegalesComponent },
  { path: 'donneesPersonnelles', component: PageDonneesPersonnellesComponent },
  { path: 'gestionCookies', component: PageCookiesComponent },
  { path: 'profil', component: PageProfilComponent },
  { path: 'ressource/:id', component: RessourceComponent },
  { path: 'admin', component: AdminComponent },
  { path: '**', component: PageNotFoundComponent }

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
