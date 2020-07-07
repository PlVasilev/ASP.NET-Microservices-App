import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AuthGuard } from '../auth.guard';
import { AllComponent } from './all/all.component';

const routes: Routes = [

];

export const OfferRoutingModule = RouterModule.forChild(routes);