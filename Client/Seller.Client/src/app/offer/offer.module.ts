import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AllComponent } from './all/all.component';
import { OfferRoutingModule } from './offer-routing.module';



@NgModule({
  declarations: [AllComponent],
  imports: [
    CommonModule,
    OfferRoutingModule
  ],
  exports:[[AllComponent]]
})
export class OfferModule { }
