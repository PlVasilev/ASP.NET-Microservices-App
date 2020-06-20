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
  private getAllPath = environment.apiUrl + '/listing/all'
  private getMinePath = environment.apiUrl + '/listing/mine'
  private detailsPath = environment.apiUrl + '/listing/'
  private updatePath = environment.apiUrl + '/listing/update'

  create(data): Observable<IListing>{
    return this.http.post<IListing>(this.createPath, data)
  }

  getListings(): Observable<Array<IListing>>{
    return this.http.get<Array<IListing>>(this.getAllPath)
  }

  getMineListings(): Observable<Array<IListing>>{
    return this.http.get<Array<IListing>>(this.getMinePath)
  }

  details(id): Observable<IListing>{
    return this.http.get<IListing>(this.detailsPath + id)
  }

  delete(id){
    return this.http.delete(this.detailsPath + id)
  }

  edit(data): Observable<IListing>{
    return this.http.put<IListing>(this.updatePath, data)
  }
}
