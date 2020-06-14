import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http'
import { Observable } from 'rxjs';
import { environment } from "../../environments/environment"
import { UserService } from '../user/user.service';
import { IListing } from '../shared/Interfaces/IListing';

@Injectable({
  providedIn: 'root'
})
export class ListingService {

  constructor(private http:HttpClient, private userService: UserService) { }

  private createPath = environment.apiUrl + '/listing/create'

  create(data): Observable<IListing>{
    let headers = new HttpHeaders();
    headers = headers.set('Authorization', `Bearer ${this.userService.getToken()}`)
    return this.http.post<IListing>(this.createPath, data, {headers})
  }

}
