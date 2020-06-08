import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HeaderComponent } from './header/header.component';
import { LandingComponent } from './landing/landing.component';
import { NotFoundComponent } from './not-found/not-found.component';
import { NotAuthorizedComponent } from './not-authorized/not-authorized.component';
import { FooterComponent } from './footer/footer.component';
import { RouterModule } from '@angular/router';



@NgModule({
  declarations: [HeaderComponent, LandingComponent, NotFoundComponent, NotAuthorizedComponent, FooterComponent],
  imports: [
    CommonModule,
    RouterModule
  ],
  exports:[
    [HeaderComponent,LandingComponent, NotFoundComponent, NotAuthorizedComponent,FooterComponent]
  ]
})
export class CoreModule { }
