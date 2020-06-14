import { Injectable, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http'
import { Observable } from 'rxjs';
import { environment } from "../../environments/environment"

@Injectable({
  providedIn: 'root'
})
export class UserService implements OnInit{

  token: string;
  username: string;

  constructor(private http:HttpClient) { }

  private loginPath = environment.apiUrl + '/identity/login'
  private registerPath = environment.apiUrl + '/identity/register'

  ngOnInit(){
    this.token = this.getToken()
    this.username = this.getUsername() 
  }

  login(data): Observable<any>{
    return this.http.post(this.loginPath, data)
    
  }

  register(data): Observable<any>{
    return this.http.post(this.registerPath, data)
  }

  saveToken(token, username){
    localStorage.setItem('token', token)
    localStorage.setItem('username', username)
  }

  getToken(){
    return localStorage.getItem('token');
  }

  getUsername(){
    return localStorage.getItem('username');
  }

  logout() {
    localStorage.removeItem('token')
    localStorage.removeItem('username')
    this.getToken()
    this.getUsername() 
    // this.router.navigate(['auth'])
  }
}
