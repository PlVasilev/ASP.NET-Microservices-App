import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { NotFoundComponent } from './core/not-found/not-found.component';
import { LandingComponent } from './core/landing/landing.component';
import { NotAuthorizedComponent } from './core/not-authorized/not-authorized.component';
import { EditComponent } from './listing/edit/edit.component';
import { AuthGuard } from './auth.guard';


const routes: Routes = [
  {
    path: '',
    pathMatch: 'full',
    component: LandingComponent
  },
  {
    path: 'listing/edit/:id',
    component: EditComponent,
    canActivate: [AuthGuard],
    data: {
      isYours: true
    }
  },
  {
    path: 'notauthorized',
    component: NotAuthorizedComponent
  },
  {
    path: '**',
    component: NotFoundComponent
  }
];

export const AppRoutingModule = RouterModule.forRoot(routes);
