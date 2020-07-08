import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';
import { IOffer } from '../shared/Interfaces/IOffer';

@Injectable({
  providedIn: 'root'
})
export class OfferService {

  constructor(private http:HttpClient) { }

  private addPath = environment.offersApiUrl + 'offer/add'
  private getCurrentPath = environment.offersApiUrl + 'offer/getCurrentOffer'
  private getAllOffersForListingPath = environment.offersApiUrl + 'offer/'
  private acceptOfferPath = environment.offersApiUrl + 'offer/accept/'
  private getAllOffersForListingCountPath = environment.offersApiUrl + 'offer/count/'

  addOffer(data): Observable<IOffer>{
    return this.http.post<IOffer>(this.addPath, data)
  }

  getCuurentOffer(data): Observable<Number>{
    return this.http.post<Number>(this.getCurrentPath, data)
  }

  getAllOffersForListing(id): Observable<Array<IOffer>>{
    return this.http.get<Array<IOffer>>(this.getAllOffersForListingPath + id)
  }

  getAllOffersForListingCount(id): Observable<Number>{
    return this.http.get<Number>(this.getAllOffersForListingCountPath + id)
  }

  accept(id){
    return this.http.get(this.acceptOfferPath + id)
  }
}
