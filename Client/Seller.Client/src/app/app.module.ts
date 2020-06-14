import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { UserModule } from './user/user.module';
import { CoreModule } from './core/core.module';
import { UserService } from './user/user.service';
import { ListingModule } from './listing/listing.module';
import {ListingService} from './listing/listing.service';

@NgModule({
  declarations: [
    AppComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    CoreModule,
    UserModule,
    ListingModule
  ],
  providers: [UserService,ListingService],
  bootstrap: [AppComponent]
})
export class AppModule { }
