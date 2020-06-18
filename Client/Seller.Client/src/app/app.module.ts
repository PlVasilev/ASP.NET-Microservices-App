import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { UserModule } from './user/user.module';
import { CoreModule } from './core/core.module';
import { UserService } from './user/user.service';
import { ListingModule } from './listing/listing.module';
import { ListingService } from './listing/listing.service';
import { TokenInterceptorService } from './shared/services/token-interceptor.service';
 //import { ErrorInterceptorService } from './shared/services/error-interceptor.service'; // "ngx-toastr": "^12.1.0",  // //"node_modules/ngx-toastr/toastr.css
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
 // import { ToastrModule } from 'ngx-toastr';

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
    ListingModule,
    BrowserAnimationsModule,
   // ToastrModule.forRoot()
  ],
  providers: [
    UserService,
    ListingService,
    {
      provide: HTTP_INTERCEPTORS,
      useClass: TokenInterceptorService,
      multi: true
    },
    // {
    //   provide: HTTP_INTERCEPTORS,
    //   useClass: ErrorInterceptorService,
    //   multi: true
    // }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
