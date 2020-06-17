import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { AddComponent } from './add/add.component';
import { ListingRoutingModule } from './listing-routing.module';
import { AllComponent } from './all/all.component';
import { DetailsComponent } from './details/details.component';


@NgModule({
  declarations: [AddComponent, AllComponent, DetailsComponent],
  imports: [
    CommonModule,
    FormsModule,
    ListingRoutingModule
  ],exports:[
    [AddComponent,AllComponent]],
})
export class ListingModule { }
